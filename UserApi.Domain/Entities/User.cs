using System;
using UserApi.Domain.Entities;

namespace UserApi.Domain.Entities
{ 
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public UserProfile? UserProfile { get; set; }


    }
}