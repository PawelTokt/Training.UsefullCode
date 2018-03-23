using System;
using Soccer.Data.Entities;

namespace Soccer.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Repository<PlayerEntity> PlayerRepository { get; set; }
        Repository<TeamEntity> TeamRepository { get; set; }

        void Save();
    }
}