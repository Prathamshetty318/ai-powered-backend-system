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

        public UserService(IGenericRepository<User> repository , IUserRepository userRepository, IMapper mapper)
        {
            _repository = repository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<UserResponseDto>> GetAllAsync()
        {
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
            return await _userRepository.ValidateUserAsync(Name, Password);

        }
    }
}
