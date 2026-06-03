using UserApi.Models;
using UserApi.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using UserApi.Interfaces;
using UserApi.Repositories;


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

        public async Task<List<User>> GetAllAsync()
        {
            return (await _repository.GetAllAsync()).ToList();
        }

        public async Task<User> GetByIdAsync (int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync (User user)  
        {
            await _repository.AddAsync(user);
        }

        public async Task <User> ValidateUserAsync (string Name, string Password)
        {
            return await _userRepository.ValidateUserAsync(Name, Password);

        }
    }
}
