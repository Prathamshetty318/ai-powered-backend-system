using Microsoft.EntityFrameworkCore;
using UserApi.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using UserApi.Application.Validators;


namespace UserApi.Application.DTOs
{
    public class CreateUserDto
    {

        public string Name { get; set; }

        public string Password { get; set; }
    }
}