using UserApi.DTOs;
using System.Collections.Generic;

namespace UserApi.Interfaces
{
    public interface IUserDapperRepository
    {
        Task<IEnumerable<UserResponseDto>>
            GetAllUserAsync();
    }
}