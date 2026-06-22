using System;
using UserApi.Interfaces;
using UserApi.Repositories;
using UserApi.Data;
using UserApi.Models;

namespace UserApi.Interfaces
{
    public interface IUnitofWork
    {
        IGenericRepository<User> users { get; }
        Task<int> SaveChangesAsync();
    }
}