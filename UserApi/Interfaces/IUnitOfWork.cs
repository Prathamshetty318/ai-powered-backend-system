using System;
using UserApi.Interfaces;
using UserApi.Repositories;

namespace UserApi.Interfaces
{
    public interface IUnitofWork
    {
        IGenericRepository<User> users { get; }
        Task<int> SaveChangesAsync();
    }
}