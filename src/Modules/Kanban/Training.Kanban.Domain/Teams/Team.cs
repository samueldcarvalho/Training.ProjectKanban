using System.Collections.Generic;
using Training.Core.Domain.Models;
using Training.Kanban.Domain.Boards;
using Training.Kanban.Domain.Teams.Joins;
using Training.Kanban.Domain.Users;

namespace Training.Kanban.Domain.Teams
{
    public class Team : Entity
    {
        public Team(string name, string description, User leader, ICollection<TeamUser> users, ICollection<Board> boards)
        {
            Name = name;
            Description = description;
            Leader = leader;
            TeamUsers = users;
            Boards = boards;
        }

        protected Team() { }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public User Leader { get; private set; }
        public virtual ICollection<TeamUser> TeamUsers { get; private set; }
        public virtual ICollection<Board> Boards { get; private set; }
    }
}
