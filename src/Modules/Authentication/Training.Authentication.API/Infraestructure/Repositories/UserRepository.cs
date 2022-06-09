using System.Collections.Generic;
using System.Linq;
using Training.Authentication.API.Interfaces;
using Training.Authentication.API.Models;

namespace Training.Authentication.API.Infraestructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        public User Get(string username, string password)
        {
            var users = new List<User>
                {
                new() {
                    Id = 1,
                    Password = "12345",
                    Username = "samuel",
                }, new()
                {
                    Id = 2,
                    Password = "qweasd",
                    Username = "debora",
                }};

            return users
                .FirstOrDefault(user => 
                    string.Equals(user.Username, username) && 
                    string.Equals(user.Password,password));
        }
    }
}
