using System.Collections.Generic;
using Training.Core.Domain.Models;
using Training.Kanban.Domain.Boards.Joins;
using Training.Kanban.Domain.Teams;
using Training.Kanban.Domain.Users;

namespace Training.Kanban.Domain.Boards
{
    public class Board : Entity
    {
        public Board(string name, string description, User leader, Team team, ICollection<BoardUser> users)
        {
            Name = name;
            Description = description;
            Leader = leader;
            Team = team;
            BoardUsers = users;
        }
        protected Board() { }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public User Leader { get; private set; }
        public Team Team { get; private set; }
        public virtual ICollection<BoardUser> BoardUsers { get; set; }
    }
}
