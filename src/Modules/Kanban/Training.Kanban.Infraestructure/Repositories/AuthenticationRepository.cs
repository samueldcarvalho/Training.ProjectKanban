using System.Collections.Generic;
using System.Linq;
using Training.Core.Domain.Models;
using Training.Kanban.Domain.Interfaces;

namespace Training.Kanban.Infraestructure.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private List<User> _users;

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
