using FormsService.DAL.Context;
using FormsService.DAL.Entities.Base;
using FormsService.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FormsService.DAL.Repository;
public class DbRepository<T> : IRepository<T>, IDisposable where T : BaseEntity
{
    private readonly DbContext _dbContext;
    private bool disposed;
    protected DbSet<T> Set { get; }
    protected virtual IQueryable<T> Items => Set;
    public DbRepository(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
        Set = _dbContext.Set<T>();
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }
        disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }


    public async Task<T?> FindById(int id, CancellationToken ct = default)
    {
        return await Items.SingleOrDefaultAsync(item => item.Id == id, ct).ConfigureAwait(false);
    }

    public async Task<IEnumerable<T>> GetAll(CancellationToken ct = default)
    {
        return await Items.AsNoTracking().ToListAsync(ct);
    }

    public async Task<T> Add(T item, CancellationToken ct = default)
    {
        if (item is null) throw new ArgumentNullException(nameof(item));

        await _dbContext.AddAsync(item, ct).ConfigureAwait(false);
        await _dbContext.SaveChangesAsync(ct).ConfigureAwait(false);
        return item;
    }

    public async Task<T> Update(T item, CancellationToken ct = default)
    {
        if (item is null) throw new ArgumentNullException(nameof(item));

        _dbContext.Update(item);
        await _dbContext.SaveChangesAsync(ct).ConfigureAwait(false);
        return item;
    }

    public async Task<T?> Remove(T? item, CancellationToken ct = default)
    {
        if (item is null) throw new ArgumentNullException(nameof(item));

        if (!await ExistsItem(item, ct))
            return null;

        _dbContext.Remove(item);
        await _dbContext.SaveChangesAsync(ct).ConfigureAwait(false);
        return item;

    }

    public async Task<T?> RemoveById(int id, CancellationToken ct = default)
    {
        var item = await FindById(id, ct);
        return await Remove(item, ct);
    }

    public async Task<bool> ExistsId(int id, CancellationToken ct = default)
    {
        return await Items.AnyAsync(item => item.Id == id, ct).ConfigureAwait(false);
    }

    public async Task<bool> ExistsItem(T? item, CancellationToken ct = default)
    {
        if (item is null) throw new ArgumentNullException(nameof(item));
        return await Items.AnyAsync(i => i.Id == item.Id, ct).ConfigureAwait(false);
    }

}