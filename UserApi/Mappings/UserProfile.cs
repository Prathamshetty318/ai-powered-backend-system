using Microsoft.AspNetCore.Mvc;
using UserApi.DTOs;
using AutoMapper;
using UserApi.Models;

namespace UserApi.Mappings
{
    public class UserProfile : Profile
    {
       public UserProfile()
        {
            CreateMap<CreateUserDto, User>();
            CreateMap<User, UserResponseDto>();
        }
    }
}

