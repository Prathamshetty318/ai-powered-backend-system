using System.Collections.Generic;
using UserApi.Domain.Entities;

namespace UserApi.Domain.Interfaces
{
    public interface IUserDapperRepository
    {
        Task<IEnumerable<User>> GetAllUserAsync();
    }
}