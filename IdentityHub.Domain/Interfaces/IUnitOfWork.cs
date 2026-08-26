using System;
using IdentityHub.Domain.Interfaces;
using IdentityHub.Domain.Entities;

namespace IdentityHub.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<User> Users { get; }

        IGenericRepository<UserProfile> UserProfiles { get; }

        IGenericRepository<AuditLog> AuditLogs { get; }

        Task<int> SaveChangesAsync();
    }
}
