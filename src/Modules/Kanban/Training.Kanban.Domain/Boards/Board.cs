using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Core.Domain.Models;
using Training.Kanban.Domain.Teams;

namespace Training.Kanban.Domain.Boards
{
    public class Board : Entity
    {
        public Board(string name, string description, User leader, Team team, ICollection<User> users)
        {
            Name = name;
            Description = description;
            Leader = leader;
            Team = team;
            Users = users;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public User Leader { get; private set; }
        public Team Team { get; private set; }
        public ICollection<User> Users { get; private set; }
    }
}
