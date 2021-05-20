using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccessLayer
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, new()
    {
        protected readonly DbContext dbContext;

        public GenericRepository(DbContext DbContext)
        {
            dbContext = DbContext;
        }

        public TEntity Add(TEntity entity)
        {
            return dbContext.Set<TEntity>().Add(entity).Entity;
        }

        
        public TEntity Find(params object[] predicate)
        {
            return dbContext.Set<TEntity>().Find(predicate);
        }
    

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return dbContext.Set<TEntity>().Where(predicate);
        }
    }
}
