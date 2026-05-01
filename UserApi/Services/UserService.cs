using UserApi.Models;

namespace UserApi.Services
{

    public class UserService
    {
        private static List<User> Users = new List<User>();

        public List<User> GetAll() => Users;

        public User? GetById(int id) =>
            Users.FirstOrDefault(u => u.Id == id);

        public void Add(User user)
        {
            Users.Add(user);
        }
    }
}
