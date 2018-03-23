using System.Linq;
using System.Data.Entity;
using Soccer.Data.Entities;
using Soccer.Data.Interfaces;
using System.Collections.Generic;

namespace Soccer.Data
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity: Entity
    {

        private readonly DbContext _dbContext;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected IDbSet<TEntity> DbSet => _dbContext.Set<TEntity>();

        public IEnumerable<TEntity> GetList()
        {
            return DbSet.ToList();
        }

        public TEntity GetById(int id)
        {
            return DbSet.FirstOrDefault(x => x.Id == id);
        }

        public void Insert(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public void Update(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var entity = DbSet.FirstOrDefault(x => x.Id == id);

            if (entity != null)
            {
                DbSet.Remove(entity);
            }
        }
    }
}