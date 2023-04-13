using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Algan.Data.Abstract;


namespace Algan.Data.Concrete.EFCore
{
    public class EfCoreGenericRepository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class
        where TContext : DbContext , new()
    {
        public void Create (TEntity entity)
        {
            using (var context = new TContext())
            {
                context.Set<TEntity>().Add(entity);
                context.SaveChanges();
            }
        }
        public void Delete (TEntity entity)
        {
            using(var context = new TContext())
            {
                context.Set<TEntity>().Remove(entity);
                context.SaveChanges();
            }
        }
        public void Update(TEntity entity)
        {
            using(var context = new TContext())
            {
                context.Entry(entity).State=EntityState.Modified;
                context.SaveChanges();
            }
        }
        public List<TEntity> GetAll()
        {
            using(var context = new TContext())
            {
                return context.Set<TEntity>().ToList();
            }
        }

        public TEntity GetByID(int id)
        {
            using(var conntext = new TContext())
            {
                return conntext.Set<TEntity>().Find(id);
            }
        }
    }
}