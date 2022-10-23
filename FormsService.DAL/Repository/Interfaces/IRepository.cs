using System.Linq.Expressions;
using FormsService.DAL.Entities.Base;

namespace FormsService.DAL.Repository.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity?> FindById(int id, CancellationToken ct = default);

        Task<IEnumerable<TEntity>> GetAll(CancellationToken ct = default);

        Task<IEnumerable<TEntity>> GetAllWithInclude(
            params Expression<Func<TEntity, object>>[] includes);

        Task<TEntity> Add(TEntity item, CancellationToken ct = default);

        Task<TEntity> PreCommit(TEntity item, CancellationToken ct = default);

        Task<TEntity> Update(TEntity item, CancellationToken ct = default);

        Task<TEntity?> Remove(TEntity? item, CancellationToken ct = default);

        Task<TEntity?> RemoveById(int id, CancellationToken ct = default);

        Task<bool> ExistsId(int id, CancellationToken ct = default);

        Task<bool> ExistsItem(TEntity? item, CancellationToken ct = default);

        IEnumerable<TEntity> GetByFilter(Func<TEntity, bool> predicate, CancellationToken ct = default);
    }
}