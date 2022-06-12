using System.Collections.Generic;
using System.Linq;
using Training.Authentication.API.Interfaces;
using Training.Authentication.API.Models;
using Training.Core.Domain.Models;

namespace Training.Authentication.API.Infraestructure.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private List<User> _users;

        public AuthenticationRepository()
        {
            _users = new List<User>
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
        }

        public User GetByLogin(string username, string password)
        {

            return _users
                .FirstOrDefault(user => 
                    string.Equals(user.Username, username) && 
                    string.Equals(user.Password,password));
        }

        public User GetById(int id) =>
            _users.FirstOrDefault(a => a.Id == id);
    }
}
