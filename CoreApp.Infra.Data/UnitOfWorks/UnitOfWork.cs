using CoreApp.Domain.Entities;
using CoreApp.Infra.Data.Context;
using CoreApp.Infra.Data.Interfaces;
using CoreApp.Infra.Data.Repositories;
using System;

public class UnitOfWork : IUnitOfWork
{
    private readonly AplicationContext _appContext;
    private GenericRepository<Teste> _testeRepository;

    public UnitOfWork()
    {
        _appContext = new AplicationContext();
    }

    public IGenericRepository<Teste> TesteRepository
    {
        get { return _testeRepository ?? (_testeRepository = new GenericRepository<Teste>(_appContext)); }
    }

    public void Commit()
    {
        _appContext.SaveChanges();
    }

    private bool disposed = false;
    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                _appContext.Dispose();
            }
        }
        disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}