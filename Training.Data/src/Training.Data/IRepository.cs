using System.Collections.Generic;

namespace Training.Data
{
    public interface IRepository<TEntity>
        where TEntity : IEntity
    {
        IEnumerable<TEntity> GetAll();

        TEntity GetById(int id);

        TEntity Insert(TEntity entity);

        TEntity Update(TEntity entity);

        void Delete(TEntity entity);
    }
}