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
                    Email = "samueldcarvalho@gmail.com",
                    Name = "Samuel de Carvalho"
                }, new()
                {
                    Id = 2,
                    Password = "qweasd",
                    Username = "debora",
                    Email = "debora_22z@hotmail.com.br",
                    Name = "Debora D. Pianezzer"
                }};

            return users
                .FirstOrDefault(user => 
                    string.Equals(user.Username, username) && 
                    string.Equals(user.Password,password));
        }
    }
}
