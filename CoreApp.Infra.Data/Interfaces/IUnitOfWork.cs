using CoreApp.Domain.Entities;
using System;

namespace CoreApp.Infra.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Teste> TesteRepository { get; }

        void Commit();
    }
}