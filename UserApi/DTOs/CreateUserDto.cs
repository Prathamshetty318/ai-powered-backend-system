using Microsoft.EntityFrameworkCore;
using UserApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using UserApi.Validators;


namespace UserApi.DTOs
{
    public class CreateUserDto
    {

        public string Name { get; set; }

        public string Password { get; set; }
    }
}