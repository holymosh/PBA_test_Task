using System;
using System.Collections.Generic;
using Common.Entities;

namespace Infrastructure
{
    public interface IGenericRepository<TEntity> where TEntity :AbstractEntity
    {
        void Create(TEntity entity);
        TEntity FindById(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> FindByPredicate(Func<TEntity, bool> predicate);
        void Remove(TEntity entity);
        void Update(TEntity entity);
    }
}
