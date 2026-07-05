using System;
using UserApi.Interfaces;
using UserApi.Repositories;
using UserApi.Data;
using UserApi.Models;

namespace UserApi.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<User> Users { get; }

        IGenericRepository<UserProfile> UserProfiles { get; }

        IGenericRepository<AuditLog> AuditLogs { get; }

        Task<int> SaveChangesAsync();
    }
}