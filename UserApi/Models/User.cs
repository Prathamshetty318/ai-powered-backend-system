using System;
using UserApi.Models;

namespace UserApi.Models
{

    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public UserProfile? UserProfile { get; set; }


    }
}