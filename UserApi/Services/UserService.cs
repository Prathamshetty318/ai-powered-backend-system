using UserApi.Models;
using UserApi.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using UserApi.Interfaces;
using UserApi.Repositories;
using UserApi.DTOs;


namespace UserApi.Services
{

    public class UserService
    {
        private readonly IGenericRepository<User> _repository;
        private readonly IUserRepository _userRepository;

        public UserService(IGenericRepository<User> repository , IUserRepository userRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
        }

        public async Task<List<UserResponseDto>> GetAllAsync()
        {
            var users = await _repository.GetAllAsync();

            return users.Select(u => new UserResponseDto
            {
                Id = u.Id,
                Name = u.Name
            }).ToList();
        }

        public async Task<UserResponseDto> GetByIdAsync (int id)
        {
            var user = await _repository.GetByIdAsync(id);

            if (user == null)
            {
                return null;
            }

            return new UserResponseDto
            {
                Id = user.Id,
                Name = user.Name
            };
        }

        public async Task AddAsync (CreateUserDto dto)  
        {
            var User = new User
            {
                Name = dto.Name,
                Password = dto.Password
            };
            await _repository.AddAsync(User);
        }

        public async Task <User> ValidateUserAsync (string Name, string Password)
        {
            return await _userRepository.ValidateUserAsync(Name, Password);

        }
    }
}
