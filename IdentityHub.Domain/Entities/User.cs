using System;
using IdentityHub.Domain.Entities;

namespace IdentityHub.Domain.Entities
{ 
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public UserProfile? UserProfile { get; set; }


    }
}
