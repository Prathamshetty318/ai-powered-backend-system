using UserApi.Models;
using UserApi.Data;

namespace UserApi.Services
{

    public class UserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public List<User> GetAll() => _context.Users.ToList();

        public User GetById(int id) => _context.Users.FirstOrDefault(u => u.Id == id);

        public void Add(User user)  
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}
