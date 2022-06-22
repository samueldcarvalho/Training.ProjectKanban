using System.Collections.Generic;
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

        protected User() { }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public ICollection<Team> Teams { get; private set; }
        public ICollection<Board> Boards { get; private set; }
    }
}
