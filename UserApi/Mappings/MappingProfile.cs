using Microsoft.AspNetCore.Mvc;
using UserApi.DTOs;
using AutoMapper;
using UserApi.Models;

namespace UserApi.Mappings
{
    public class MappingProfile : Profile
    {
       public MappingProfile()
        {
            CreateMap<CreateUserDto, User>();
            CreateMap<User, UserResponseDto>();
        }
    }
}

