using UserApi.Models;
using UserApi.Services;


namespace UserApi.Interfaces
{
    public interface IUserRepository
    {

        Task<User> ValidateUserAsync(
            string name,
            string password);

        Task<User> GetByNameAsync(string name);
    }
}   