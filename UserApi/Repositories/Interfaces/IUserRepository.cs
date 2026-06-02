using UserApi.Models;
using UserApi.Services;


namespace UserApi.Reposotories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();

        Task<User> GetByIdAsync();

        Task AddAsync(User user);

        Task<User> ValidateUser(
            string name,
            string password);
    }
}   