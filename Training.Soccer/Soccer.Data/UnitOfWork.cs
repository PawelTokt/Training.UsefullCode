using System;
using Soccer.Data.Entities;
using Soccer.Data.Interfaces;

namespace Soccer.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SoccerDbContext _dbContext;
        private bool _isDisposed;

        public UnitOfWork(string connectionString)
        {
            _dbContext = new SoccerDbContext(connectionString);
            PlayerRepository = new Repository<PlayerEntity>(_dbContext);
            TeamRepository = new Repository<TeamEntity>(_dbContext);
        }

        public Repository<PlayerEntity> PlayerRepository { get; set; }
        public Repository<TeamEntity> TeamRepository { get; set; }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            _isDisposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}