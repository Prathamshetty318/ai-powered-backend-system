using Microsoft.EntityFrameworkCore;
using UserApi.Entities;

namespace UserApi.DTOs
{
    public class UserResponseDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}