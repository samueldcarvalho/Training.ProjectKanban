using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Core.Domain.Models;
using Training.Kanban.Domain.Boards;
using Training.Kanban.Domain.Teams;

namespace Training.Kanban.Domain.Users
{
    public class User : Entity
    {
        public User(string name, string email, string username, string password, ICollection<Team> teams, ICollection<Board> boards)
        {
            Name = name;
            Email = email;
            Username = username;
            Password = password;
            Teams = teams;
            Boards = boards;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public virtual ICollection<Team> Teams { get; private set; }
        public virtual ICollection<Board> Boards { get; private set; }
    }
}
