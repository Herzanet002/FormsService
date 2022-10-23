using System.Linq.Expressions;
using FormsService.DAL.Entities.Base;

namespace FormsService.DAL.Repository.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T?> FindById(int id, CancellationToken ct = default);

        Task<IEnumerable<T>> GetAll(CancellationToken ct = default);

        Task<IEnumerable<T>> GetAllWithEagerLoading(
            params Expression<Func<T, object>>[] includes);

        Task<T> Add(T item, CancellationToken ct = default);

        Task<T> PreCommit(T item, CancellationToken ct = default);

        Task<T> Update(T item, CancellationToken ct = default);

        Task<T?> Remove(T? item, CancellationToken ct = default);

        Task<T?> RemoveById(int id, CancellationToken ct = default);

        Task<bool> ExistsId(int id, CancellationToken ct = default);

        Task<bool> ExistsItem(T? item, CancellationToken ct = default);

        IEnumerable<T> GetByFilter(Func<T, bool> predicate, CancellationToken ct = default);
    }
}