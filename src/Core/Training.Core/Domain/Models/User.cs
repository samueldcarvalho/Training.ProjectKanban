using System.Collections.Generic;
using Training.Core.Domain.Models;

namespace Training.Core.Domain.Models
{
    public class User : Entity
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }

        public User() { }
        public User(string email, string username, string password)
        {
            Email = email;
            Username = username;
            Password = password;
        }
    }
}
