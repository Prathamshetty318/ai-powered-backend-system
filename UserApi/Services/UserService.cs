using UserApi.Models;
using UserApi.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using UserApi.Interfaces;
using UserApi.Repositories;
using UserApi.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using AutoMapper;
using UserApi.Mappings;


namespace UserApi.Services
{

    public class UserService
    {
        private readonly IGenericRepository<User> _repository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IUserDapperRepository _dapperRepository;
        private readonly ILogger<UserService> _logger;

        public UserService(IGenericRepository<User> repository , IUserRepository userRepository, IMapper mapper, IUserDapperRepository dapperRepository, ILogger<UserService> logger)
        {
            _repository = repository;
            _userRepository = userRepository;
            _mapper = mapper;
            _dapperRepository = dapperRepository;
            _logger = logger;
        }

        public async Task<List<UserResponseDto>> GetAllAsync()
        {
            _logger.LogInformation("Fetching all Users");
            var users = await _repository.GetAllAsync();

            return _mapper.Map<List<UserResponseDto>>(users);

        }

        public async Task<UserResponseDto> GetByIdAsync (int id)
        {
            var user = await _repository.GetByIdAsync(id);

            if (user == null)
            {
                return null;
            }

            return _mapper.Map<UserResponseDto>(user);

        }

        public async Task AddAsync (CreateUserDto dto)  
        {
            var User = _mapper.Map<User>(dto);
            await _repository.AddAsync(User);
        }

        public async Task <User> ValidateUserAsync (string Name, string Password)
        {
            _logger.LogInformation("User {User} Logged in", Name);
            _logger.LogWarning("User {User} attempted to log in with incorrect password", Name);
            return await _userRepository.ValidateUserAsync(Name, Password);

        }

        public async Task<IEnumerable<UserResponseDto>> GetUsersDapperAsync()
        {
            _logger.LogInformation("Fetching all Users");
            return await _dapperRepository.GetAllUserAsync();
        }
    }
}
