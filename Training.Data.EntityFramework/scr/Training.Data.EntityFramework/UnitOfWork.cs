using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Training.Data.EntityFramework
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;
        private readonly IDictionary<Type, object> _repositories;
        private bool _isDisposed;

        public UnitOfWork(DbContext dbContext)
        {
            _repositories = new Dictionary<Type, object>();
            _dbContext = dbContext;
        }

        protected DbContext DbContext => _dbContext;

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        protected void RegisterRepository<TEntity>(IRepository<TEntity> repository)
            where TEntity : IEntity
        {
            _repositories[typeof(TEntity)] = repository;
        }

        protected virtual IRepository<TEntity> GetRepository<TEntity>()
            where TEntity : IEntity
        {
            return (IRepository<TEntity>)_repositories[typeof(TEntity)];
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
            {
                return;
            }

            if (_isDisposed)
            {
                return;
            }

            _isDisposed = true;
            GC.SuppressFinalize(this);
        }
    }
}