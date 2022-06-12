using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Core.Domain.Models;
using Training.Kanban.Domain.Boards;
using Training.Kanban.Domain.Boards.Joins;
using Training.Kanban.Domain.Teams;
using Training.Kanban.Domain.Teams.Joins;

namespace Training.Kanban.Domain.Users
{
    public class User : Entity
    {
        public User(string name, string email, string username, string password, ICollection<TeamUser> teams, ICollection<BoardUser> boards)
        {
            Name = name;
            Email = email;
            Username = username;
            Password = password;
            TeamUsers = teams;
            BoardUsers = boards;
        }

        protected User() { }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public virtual ICollection<TeamUser> TeamUsers { get; private set; }
        public virtual ICollection<BoardUser> BoardUsers { get; private set; }
    }
}
