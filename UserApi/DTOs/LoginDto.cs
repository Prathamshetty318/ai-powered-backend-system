using Microsoft.EntityFrameworkCore;
using UserApi.Models;

namespace UserApi.DTOs
{
    public class LoginDto
    {
        public string Name { get; set; }

        public string Password { get; set; }
    }
}