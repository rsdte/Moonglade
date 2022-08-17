using Microsoft.EntityFrameworkCore;
using Moonglade.Domain;
using System.Linq.Expressions;

namespace Moonglade.EntityFrameworkCore
{
    public abstract class RepositoryBase<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : class
    {
        private readonly MoongladeDbContext dbContext;

        public RepositoryBase(MoongladeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public abstract Task DeleteableAsync(TEntity entity);

        public async Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await this.dbContext.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate)
        {

            return await this.dbContext.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(TKey id)
        {
            return await this.dbContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> orderby, bool isDesc)
        {
            if (isDesc)
                return await this.dbContext.Set<TEntity>().Where(predicate).OrderByDescending(orderby).ToArrayAsync();
            return await this.dbContext.Set<TEntity>().Where(predicate).OrderBy(orderby).ToArrayAsync();
        }

        public async Task<IPage<TEntity>> GetPageAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> orderby, bool isDesc, int pageIndex, int pageSize)
        {
            var page = new Page<TEntity>();
            IOrderedQueryable<TEntity> entities;
            if (isDesc)
                entities = this.dbContext.Set<TEntity>().Where(predicate).OrderByDescending(orderby);
            else
                entities = this.dbContext.Set<TEntity>().Where(predicate).OrderBy(orderby);
            var count = await entities.CountAsync();
            page.Count = (int)Math.Floor(count / pageSize * 0.1);
            page.Data = await entities.Skip(pageIndex - 1).Take(pageSize).ToListAsync();
            return page;
        }

        public async Task InsertableAsync(TEntity entity)
        {
            await this.dbContext.Set<TEntity>().AddAsync(entity);
        }

        public Task InsertableAsync(TEntity[] entities)
        {
            return this.dbContext.Set<TEntity>().AddRangeAsync(entities);
        }

        public Task UpdateableAsync(TEntity entity)
        {
            this.dbContext.Set<TEntity>().Update(entity);
            return Task.CompletedTask;
        }

        public Task UpdateableAsync(TEntity[] entities)
        {
            this.dbContext.Set<TEntity>().UpdateRange(entities);
            return Task.CompletedTask;
        }
    }
}