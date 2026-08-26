using IdentityHub.Domain.Entities;

namespace IdentityHub.Application.DTOs
{
    public class RegisterUserDto
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; } 
        public string PhoneNumber { get; set; }
    }
}
