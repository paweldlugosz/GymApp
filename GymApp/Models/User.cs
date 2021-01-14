using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymApp.Models
{
    public class User
    {
       public string Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public User(string login, string password)
        {
            Id = Guid.NewGuid().ToString();
            Login = login;
            Password = password;
        }
    }
}
