using System.Collections.Generic;
using IdentityHub.Domain.Entities;

namespace IdentityHub.Domain.Interfaces
{
    public interface IUserDapperRepository
    {
        Task<IEnumerable<User>> GetAllUserAsync();
    }
}
