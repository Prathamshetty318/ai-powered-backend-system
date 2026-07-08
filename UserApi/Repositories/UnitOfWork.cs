using Microsoft.EntityFrameworkCore;
using UserApi.Data;
using UserApi.Interfaces;
using UserApi.Repositories;
using UserApi.Entities;

namespace UserApi.Repositories
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