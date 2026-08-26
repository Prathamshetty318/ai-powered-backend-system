using IdentityHub.Domain.Entities;
using IdentityHub.Infrastructure.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using IdentityHub.Domain.Interfaces;

namespace IdentityHub.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> ValidateUserAsync(string Name , string Password)
        {
            return await _context.Users
                .FirstOrDefaultAsync
                (u => u.Name == Name && u.Password == Password);

        }

        public async Task<User> GetByNameAsync(string name)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Name == name);
        }
    }
}
