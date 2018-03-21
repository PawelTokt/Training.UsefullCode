using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Training.Data.EntityFramework
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : Entity
    {
        public Repository(DbContext dbContext)
        {
            DbContext = dbContext;
        }

        protected DbContext DbContext { get; }
        protected IDbSet<TEntity> DbSet => DbContext.Set<TEntity>();


        public IEnumerable<TEntity> GetAll()
        {
            return DbSet;
        }

        public TEntity GetById(int id)
        {
            return DbSet.FirstOrDefault(x => x.Id == id);
        }

        public TEntity Insert(TEntity entity)
        {
            return DbSet.Add(entity);
        }

        public TEntity Update(TEntity entity)
        {
            DbSet.Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public void Delete(int id)
        {
            var entity = DbSet.FirstOrDefault(x => x.Id == id);
            if (entity != null)
            {
                DbSet.Remove(entity);
            }
        }

        public void Delete(TEntity entity)
        {
            if (DbContext.Entry(entity).State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }
            DbSet.Remove(entity);
        }
    }
}