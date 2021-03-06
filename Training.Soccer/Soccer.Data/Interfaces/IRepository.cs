﻿using System.Collections.Generic;

namespace Soccer.Data.Interfaces
{
    public interface IRepository<TEntity>
        where TEntity : IEntity
    {
        IEnumerable<TEntity> GetList();

        TEntity GetById(int id);

        void Insert(TEntity entity);

        void Update(TEntity entity);

        void Delete(int id);
    }
}