using UserApi.Domain.Entities;
using UserApi.Services;


namespace UserApi.Domain.Interfaces
{
    public interface IUserRepository
    {

        Task<User> ValidateUserAsync(
            string name,
            string password);

        Task<User> GetByNameAsync(string name);
    }
}   