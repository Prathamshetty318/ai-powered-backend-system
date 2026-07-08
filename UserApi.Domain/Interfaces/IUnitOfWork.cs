using System;
using UserApi.Domain.Interfaces;
using UserApi.Domain.Entities;

namespace UserApi.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<User> Users { get; }

        IGenericRepository<UserProfile> UserProfiles { get; }

        IGenericRepository<AuditLog> AuditLogs { get; }

        Task<int> SaveChangesAsync();
    }
}