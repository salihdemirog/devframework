using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using DevFramework.Entities;

namespace DevFramework.DataAccess.EntityFramework
{
    public abstract class EntityRepositoryBase<TEntity> : IEntityRepository<TEntity>
        where TEntity : class, IEntity
    {
        private readonly DbContext _dbContext;

        protected EntityRepositoryBase(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual TEntity InsertContext(DbContext context, TEntity entity)
        {
            var dbEntry = context.Entry(entity);
            dbEntry.State = EntityState.Added;

            context.SaveChanges();

            return dbEntry.Entity;
        }

        public virtual TEntity UpdateContext(DbContext context, TEntity entity)
        {
            var dbEntry = context.Entry(entity);
            dbEntry.State = EntityState.Modified;

            context.SaveChanges();

            return dbEntry.Entity;
        }

        public virtual void DeleteContext(DbContext context, TEntity entity)
        {
            var dbEntry = context.Entry(entity);
            dbEntry.State = EntityState.Deleted;

            context.SaveChanges();
        }

        public TEntity Insert(TEntity entity)
        {
            return InsertContext(_dbContext, entity);
        }

        public IEnumerable<TEntity> Insert(IEnumerable<TEntity> entities)
        {
            var dbEntry = _dbContext.Set<TEntity>().AddRange(entities);
            _dbContext.SaveChanges();

            return dbEntry;
        }

        public TEntity Update(TEntity entity)
        {
            return UpdateContext(_dbContext, entity);
        }

        public void Delete(TEntity entity)
        {
            DeleteContext(_dbContext, entity);
        }

        public void Delete(IEnumerable<TEntity> entities)
        {
            _dbContext.Set<TEntity>().RemoveRange(entities);

            _dbContext.SaveChanges();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            return _dbContext.Set<TEntity>().SingleOrDefault(filter);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> GetAllOrderByAsc<TKey>(Expression<Func<TEntity, TKey>> orderExpression, Expression<Func<TEntity, TKey>> thenExpression = null)
        {
            if (thenExpression == null)
                return _dbContext.Set<TEntity>().OrderBy(orderExpression).ToList();

            return _dbContext.Set<TEntity>().OrderBy(orderExpression).ThenBy(thenExpression).ToList();
        }

        public IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> filter)
        {
            //if (asNoTracking)
            //    return context.Set<TEntity>().AsNoTracking().Where(filter).ToList();

            return _dbContext.Set<TEntity>().Where(filter).ToList();
        }

        public IEnumerable<TEntity> GetListOrderByAsc<TKey>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TKey>> orderExpression)
        {
            return _dbContext.Set<TEntity>().Where(filter).OrderBy(orderExpression).ToList();
        }

        public IEnumerable<TEntity> GetListOrderByDesc<TKey>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TKey>> orderExpression)
        {
            return _dbContext.Set<TEntity>().Where(filter).OrderByDescending(orderExpression).ToList();
        }

        public bool IsExist(Expression<Func<TEntity, bool>> filter)
        {
            return _dbContext.Set<TEntity>().Any(filter);
        }

        public int Count(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null
                ? _dbContext.Set<TEntity>().Count()
                : _dbContext.Set<TEntity>().Count(filter);
        }
    }
}
