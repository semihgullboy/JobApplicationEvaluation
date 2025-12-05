using System.Linq.Expressions;

namespace JobApplicationEvaluation.Core.DataAccess
{
    public interface IEntityRepository<TEntity>
    {
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter = null);
        Task<TResult> SelectPropsAsync<TResult>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TResult>> selector);
        Task AddAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task UpdateSinglePropAsync(TEntity entity, params Expression<Func<TEntity, object>>[] updatedProperties);
        Task UpdateAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        Task<int> CountAsync(Expression<Func<TEntity, bool>> filter = null);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);
        Task DeleteRangeAsync(IEnumerable<TEntity> entities);
    }
}
