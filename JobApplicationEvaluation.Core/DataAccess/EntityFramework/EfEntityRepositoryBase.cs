using JobApplicationEvaluation.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JobApplicationEvaluation.Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class
        where TContext : DbContext
    {
        protected readonly TContext _context;

        public EfEntityRepositoryBase(TContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            if (entity is BaseEntity baseEntity)
            {
                baseEntity.IsActive = false;
                _context.Set<TEntity>().Update(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null
                ? await _context.Set<TEntity>().AsNoTracking().ToListAsync()
                : await _context.Set<TEntity>().Where(filter).AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            return await _context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(filter);
        }

        public async Task<TResult> SelectPropsAsync<TResult>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TResult>> selector)
        {
            return await _context.Set<TEntity>().AsNoTracking().Where(filter).Select(selector).FirstOrDefaultAsync();
        }


        public async Task UpdateSinglePropAsync(TEntity entity, params Expression<Func<TEntity, object>>[] updatedProperties)
        {
            _context.Set<TEntity>().Attach(entity);
            foreach (var prop in updatedProperties)
                _context.Entry(entity).Property(prop).IsModified = true;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _context.Set<TEntity>().AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            if (filter != null)
            {
                return await _context.Set<TEntity>().CountAsync(filter);
            }

            return await _context.Set<TEntity>().CountAsync();
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().AnyAsync(predicate);
        }

        public async Task DeleteRangeAsync(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
            await _context.SaveChangesAsync();
        }
    }
}
