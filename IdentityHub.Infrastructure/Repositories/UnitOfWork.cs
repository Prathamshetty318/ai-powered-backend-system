using Microsoft.EntityFrameworkCore;
using IdentityHub.Infrastructure.Data;
using IdentityHub.Domain.Interfaces;
using IdentityHub.Infrastructure.Repositories;
using IdentityHub.Domain.Entities;

namespace IdentityHub.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public IGenericRepository<User> Users { get; }

        public IGenericRepository<UserProfile> UserProfiles { get; }

        public IGenericRepository<AuditLog> AuditLogs { get; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;

            Users = new GenericRepository<User>(_context);

            UserProfiles = new GenericRepository<UserProfile>(_context);

            AuditLogs = new GenericRepository<AuditLog>(_context);

        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
