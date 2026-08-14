using UserApi.Domain.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using UserApi.Domain.Interfaces;
using UserApi.Application.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using AutoMapper;
using UserApi.Application.Mapping;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace UserApi.Application.Services
{

    public class UserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IUserDapperRepository _dapperRepository;
        private readonly ILogger<UserService> _logger;
        private readonly IDistributedCache _cache;

        public UserService(IUserRepository userRepository, 
            IMapper mapper, 
            IUserDapperRepository dapperRepository, 
            ILogger<UserService> logger,
            IDistributedCache cache,
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

        public async Task <User> ValidateUserAsync (string Name, string Password)
        {
            _logger.LogInformation("User {User} Logged in", Name);

            if (Password == Password)
            {
                _logger.LogWarning("User {User} attempted to log in with incorrect password", Name);
            }
            return await _userRepository.ValidateUserAsync(Name, Password);

        }

    }
}
