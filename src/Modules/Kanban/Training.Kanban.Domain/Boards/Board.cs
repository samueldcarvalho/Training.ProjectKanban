using System.Collections.Generic;
using Training.Core.Domain.Models;
using Training.Kanban.Domain.Teams;
using Training.Kanban.Domain.Users;

namespace Training.Kanban.Domain.Boards
{
    public class Board : Entity
    {
        public Board(string name, string description, User leader, Team team, ICollection<User> users, int leaderId)
        {
            Name = name;
            Description = description;
            Leader = leader;
            Team = team;
            Users = users;
            LeaderId = leaderId;
        }
        protected Board() { }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public int LeaderId { get; private set; }
        public User Leader { get; private set; }
        public Team Team { get; private set; }
        public ICollection<User> Users { get; set; }
    }
}
