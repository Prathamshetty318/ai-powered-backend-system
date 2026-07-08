using UserApi.Entities;
using UserApi.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using UserApi.Interfaces;
using UserApi.Repositories;
using UserApi.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using AutoMapper;
using UserApi.Mapping;
using Microsoft.Extensions.Caching.Memory;

namespace UserApi.Services
{

    public class UserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IUserDapperRepository _dapperRepository;
        private readonly ILogger<UserService> _logger;
        private readonly IMemoryCache _cache;

        public UserService(IUserRepository userRepository, 
            IMapper mapper, 
            IUserDapperRepository dapperRepository, 
            ILogger<UserService> logger,
            IMemoryCache cache,
            IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _dapperRepository = dapperRepository;
            _logger = logger;
            _cache = cache;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<UserResponseDto>> GetAllAsync()
        {
            _logger.LogInformation("Fetching all Users");
            var users = await _unitOfWork.Users.GetAllAsync();

            return _mapper.Map<List<UserResponseDto>>(users);

        }

        public async Task<UserResponseDto> GetByIdAsync (int id)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(id);

            if (user == null)
            {
                return null;
            }

            return _mapper.Map<UserResponseDto>(user);

        }

        public async Task<UserResponseDto> GetByNameAsync(string name)
        {
            var user = await _userRepository.GetByNameAsync(name);

            if (user == null)
            {
                return null;
            }

            return _mapper.Map<UserResponseDto>(user);

        }

        public async Task<IEnumerable<UserResponseDto>> GetUsersDapperAsync()
        {

            if (_cache.TryGetValue("all_users", out IEnumerable<UserResponseDto> user))
            {
                _logger.LogInformation("Users returned from cache");

                return user;
            }


            _logger.LogInformation("Fetching all Users");

            var users = await _dapperRepository.GetAllUserAsync();

            _cache.Set("all_users", users, TimeSpan.FromMinutes(5));
            _logger.LogInformation("Users returned from database and cached");

            return users;
        }

        public async Task RegisterUserAsync (RegisterUserDto dto)  
        {
            var User = _mapper.Map<User>(dto);
            await _unitOfWork.Users.AddAsync(User);

            await _unitOfWork.AuditLogs.AddAsync(
                new AuditLog
                {
                    Action = $"User {User.Name} registered",
                });

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task <User> ValidateUserAsync (string Name, string Password)
        {
            _logger.LogInformation("User {User} Logged in", Name);
            _logger.LogWarning("User {User} attempted to log in with incorrect password", Name);
            return await _userRepository.ValidateUserAsync(Name, Password);

        }

    }
}
