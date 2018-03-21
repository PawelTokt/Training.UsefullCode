using System;

namespace Training.Data
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
    }
}