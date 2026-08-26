using Microsoft.EntityFrameworkCore;
using IdentityHub.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using IdentityHub.Application.Validators;


namespace IdentityHub.Application.DTOs
{
    public class CreateUserDto
    {

        public string Name { get; set; }

        public string Password { get; set; }
    }
}
