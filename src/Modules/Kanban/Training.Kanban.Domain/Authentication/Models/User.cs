using System.ComponentModel.DataAnnotations;
using Training.Core.Data.Repositories;
using Training.Core.Domain.Models;

namespace Training.Kanban.Domain.Authentication.Models
{
    public class User : Entity, IAggregateRoot
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }

    }
}
