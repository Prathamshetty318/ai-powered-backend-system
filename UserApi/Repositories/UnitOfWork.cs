using Microsoft.EntityFrameworkCore;
using UserApi.Data;
using UserApi.Interfaces;
using UserApi.Repositories;
using UserApi.Models;

namespace UserApi.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public IGenericRepository<User> Users { get; }

        public IGenericRepository<UserProfile> userProfiles { get; }

        public IGenericRepository<AuditLog> AuditLog { get; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;

            Users = new GenericRepository<User>(_context);

            userProfiles = new GenericRepository<UserProfile>(_context);

            AuditLog = new GenericRepository<AuditLog>(_context);

        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}