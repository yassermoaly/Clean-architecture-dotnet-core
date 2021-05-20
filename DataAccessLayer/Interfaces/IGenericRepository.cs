using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccessLayer.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        TEntity Add(TEntity entity);     
        TEntity Find(params object[] predicate);
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
    }
}
