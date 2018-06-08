using System;
using System.Collections.Generic;
using System.Linq;
using Common.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class EfGenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity:AbstractEntity
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public EfGenericRepository(IDbContextWrapper context)
        {
            _context = context.Context;
            _dbSet = context.Context.Set<TEntity>();
        }


        public void Create(TEntity entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public TEntity FindById(int id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public IEnumerable<TEntity> FindByPredicate(Func<TEntity, bool> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate);
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
