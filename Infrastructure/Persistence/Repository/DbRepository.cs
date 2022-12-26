using System.Linq.Expressions;
using Domain.Common;
using Infrastructure.Persistence.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repository;

public class DbRepository<TEntity> : IRepository<TEntity>, IDisposable where TEntity : BaseEntity
{
    private readonly DatabaseContext _dbContext;
    private bool _disposed;
    protected DbSet<TEntity> Set { get; }
    protected IQueryable<TEntity> Items => Set;

    public DbRepository(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
        Set = _dbContext.Set<TEntity>();
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }
        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public async Task<TEntity?> FindById(int id, CancellationToken ct = default)
    {
        return await Items.SingleOrDefaultAsync(item => item.Id == id, ct).ConfigureAwait(false);
    }

    public async Task<IEnumerable<TEntity>> GetAll(CancellationToken ct = default)
    {
        return await Items.AsNoTracking().ToListAsync(ct).ConfigureAwait(false);
    }

    public async Task<IEnumerable<TEntity>> GetAllWithInclude(params Expression<Func<TEntity, object>>[] includes)
    {
        var query = includes.Aggregate(Items, (current, include) => current.Include(include));
        return await query.ToListAsync().ConfigureAwait(false);
    }

    public async Task<TEntity> Add(TEntity item, CancellationToken ct = default)
    {
        if (item is null) throw new ArgumentNullException(nameof(item));

        await _dbContext.AddAsync(item, ct).ConfigureAwait(false);
        await _dbContext.SaveChangesAsync(ct).ConfigureAwait(false);
        return item;
    }

    public async Task<TEntity> PreCommit(TEntity item, CancellationToken ct = default)
    {
        if (item is null) throw new ArgumentNullException(nameof(item));

        await _dbContext.AddAsync(item, ct).ConfigureAwait(false);
        return item;
    }

    public async Task<TEntity> Update(TEntity item, CancellationToken ct = default)
    {
        if (item is null) throw new ArgumentNullException(nameof(item));

        _dbContext.Update(item);
        await _dbContext.SaveChangesAsync(ct).ConfigureAwait(false);
        return item;
    }

    public async Task<TEntity?> Remove(TEntity? item, CancellationToken ct = default)
    {
        if (item is null) throw new ArgumentNullException(nameof(item));

        if (!await ExistsItem(item, ct))
            return null;

        _dbContext.Remove(item);
        await _dbContext.SaveChangesAsync(ct).ConfigureAwait(false);
        return item;
    }

    public async Task<TEntity?> RemoveById(int id, CancellationToken ct = default)
    {
        var item = await FindById(id, ct);
        return await Remove(item, ct);
    }

    public async Task<bool> ExistsId(int id, CancellationToken ct = default)
    {
        return await Items.AnyAsync(item => item.Id == id, ct).ConfigureAwait(false);
    }

    public async Task<bool> ExistsItem(TEntity? item, CancellationToken ct = default)
    {
        if (item is null) throw new ArgumentNullException(nameof(item));
        return await Items.AnyAsync(i => i.Id == item.Id, ct).ConfigureAwait(false);
    }

    public IEnumerable<TEntity> GetByFilter(Func<TEntity, bool> predicate, CancellationToken ct = default)
    {
        return Items.AsEnumerable().Where(predicate).ToList();
    }
}