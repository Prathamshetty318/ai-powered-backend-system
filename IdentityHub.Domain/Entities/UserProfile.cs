using System;
using IdentityHub.Domain.Entities;

namespace IdentityHub.Domain.Entities
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
