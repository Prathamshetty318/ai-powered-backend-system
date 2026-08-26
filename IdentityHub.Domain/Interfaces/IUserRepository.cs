using IdentityHub.Domain.Entities;

namespace IdentityHub.Domain.Interfaces
{
    public interface IUserRepository
    {

        Task<User> ValidateUserAsync(
            string name,
            string password);

        Task<User> GetByNameAsync(string name);
    }
}   
