using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Sample.Infra.Interface.Repository;

namespace Sample.Infra.EF.Repository
{
    internal class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal Repository(DbContext dbContext)
        {
            _dbSet = dbContext.Set<TEntity>();
        }

        private readonly DbSet<TEntity> _dbSet;

        public TEntity Find(params object[] keyValues)
        {
            return _dbSet.Find(keyValues);
        }

        public IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public IEnumerable<TEntity> FindAll()
        {
            return _dbSet.Select(x => x);
        }

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }
    }
}
