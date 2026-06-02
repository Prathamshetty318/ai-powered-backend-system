using UserApi.Models;
using UserApi.Data;
using system.linq;
using Microsoft.EntityFrameworkCore;
using UserApi.Services;
using UserApi.Repositories;

namespace UserApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<User> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task(User) GetByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(uint => u.Id == id);
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> ValidateUserAsync(string Name, string Password)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Name == Name && u.Password == Password);

        }
    }
}