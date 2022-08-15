using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Moonglade.Domain
{
    public interface IRepository<TEntity, TKey>
    {
        void Insertable(TEntity entity);
        void Insertable(TEntity[] entities);
        void Updateable(TEntity entity);
        void Updateable(TEntity[] entities);
        void Deleteable(TEntity entity);
        TEntity GetById(TKey id);
        TEntity Find(Expression<Func<TEntity, bool>> expression);
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> expression);
        IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> expression, Expression<Func<TEntity, object>> orderby, bool isDesc);
        IPage<TEntity> GetPage(Expression<Func<TEntity, bool>> expression, Expression<Func<TEntity, object>> orderby, bool isDesc, int pageIndex, int pageSize);
    }
}
