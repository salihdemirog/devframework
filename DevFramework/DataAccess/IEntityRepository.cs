using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DevFramework.Entities;

namespace DevFramework.DataAccess
{
    public interface IEntityRepository<TEntity>
        where TEntity : class, IEntity
    {
        TEntity Insert(TEntity entity);

        IEnumerable<TEntity> Insert(IEnumerable<TEntity> entities);

        TEntity Update(TEntity entity);

        void Delete(TEntity entity);

        void Delete(IEnumerable<TEntity> entities);

        TEntity Get(Expression<Func<TEntity, bool>> filter);

        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> GetAllOrderByAsc<TKey>(Expression<Func<TEntity, TKey>> orderExpression, Expression<Func<TEntity, TKey>> thenExpression = null);

        IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> filter);

        IEnumerable<TEntity> GetListOrderByAsc<TKey>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TKey>> orderExpression);

        IEnumerable<TEntity> GetListOrderByDesc<TKey>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TKey>> orderExpression);

        bool IsExist(Expression<Func<TEntity, bool>> filter);

        int Count(Expression<Func<TEntity, bool>> filter = null);
    }
}