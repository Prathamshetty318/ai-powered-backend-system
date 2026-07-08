using Microsoft.AspNetCore.Mvc;
using UserApi.Application.DTOs;
using AutoMapper;
using UserApi.Domain.Entities;

namespace UserApi.Application.Mapping
{
    public class MappingProfile : Profile
    {
       public MappingProfile()
        {
            CreateMap<CreateUserDto, User>();
            CreateMap<User, UserResponseDto>();
            CreateMap<RegisterUserDto, User>()
                .ForPath(
                dest => dest.UserProfile.Email,
                opt => opt.MapFrom(src => src.Email))
                .ForPath(
                dest => dest.UserProfile.PhoneNumber,
                opt => opt.MapFrom(src => src.PhoneNumber));
        }
    }
}

