using System.Linq.Expressions;

namespace Moonglade.Domain
{
    public interface IRepository<TEntity, TKey>
    {
        Task InsertableAsync(TEntity entity);
        Task InsertableAsync(TEntity[] entities);
        Task UpdateableAsync(TEntity entity);
        Task UpdateableAsync(TEntity[] entities);
        Task DeleteableAsync(TEntity entity);
        Task<TEntity?> GetByIdAsync(TKey id);
        Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> orderby, bool isDesc);
        Task<IPage<TEntity>> GetPageAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> orderby, bool isDesc, int pageIndex, int pageSize);
    }
}
