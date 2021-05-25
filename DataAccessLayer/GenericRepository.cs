using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using SharedConfig.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, new()
    {
        protected readonly DbContext dbContext;
        private readonly AppConfig _config;
        public GenericRepository(DbContext DbContext, AppConfig config)
        {
            dbContext = DbContext;
            _config = config;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            return (await dbContext.Set<TEntity>().AddAsync(entity)).Entity;
        }

        public async Task<TEntity> FindAsync(params object[] predicate)
        {
            return await dbContext.Set<TEntity>().FindAsync(predicate);
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return dbContext.Set<TEntity>().Where(predicate);
        }
    }
}
