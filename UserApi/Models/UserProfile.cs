using System;
using UserApi.Models;

namespace UserApi.Models
{

    public class UserProfile
    {
        public int Id { get; set; }
        
        public int UserId { get; set; }
        
        public string  Email { get; set; }

        public string PhoneNumber { get; set; }

        public User? User { get; set; }

    }
}