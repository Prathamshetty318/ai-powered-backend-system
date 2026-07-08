using UserApi.Domain.Entities;

namespace UserApi.Application.DTOs
{
    public class LoginDto
    {
        public string Name { get; set; }

        public string Password { get; set; }
    }
}