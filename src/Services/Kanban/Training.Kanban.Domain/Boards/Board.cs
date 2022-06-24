using System;
using System.Collections.Generic;
using System.Linq;
using Training.Core.Data.Repositories;
using Training.Core.Domain.Models;
using Training.Kanban.Domain.Teams;
using Training.Kanban.Domain.Users;

namespace Training.Kanban.Domain.Boards
{
    public class Board : Entity, IAggregateRoot
    {
        public string Name { get; private set; }
        public string Description { get; private set; } = "";
        public int LeaderId { get; private set; }
        public User Leader { get; private set; }
        public int TeamId { get; private set; }
        public Team Team { get; private set; }
        public ICollection<User> Members { get; set; }

        protected Board() { }
        public Board(string name, string description, User userLeader, int teamId)
        {
            Name = name;
            Description = description;
            TeamId = teamId;
            Leader = userLeader;
            LeaderId = userLeader.Id;

            Members = new List<User>() { userLeader };
        }

        public void ChangeLeader(int userId)
        {
            if(userId <= 0)
                throw new Exception("UserId was not passed to change board's leader.");

            var user = Members.FirstOrDefault(u =>
                u.Id == userId);

            if (user == null)
                throw new Exception("User doesn't participate in this board.");

            LeaderId = user.Id;
            Leader = user;
        }

        public void RemoveMember(int userId)
        {
            if (userId <= 0)
                throw new Exception("UserId was not passed to remove from the board.");

            var user = Members.FirstOrDefault(u => 
                u.Id == userId);

            if (user == null)
                throw new Exception("User doesn't participate in this board.");

            Members.Remove(user);
        }

        public void AddMember(User user)
        {
            if(user == null)
                throw new ArgumentNullException(nameof(user));

            if (Members.Any(u => u.Id == user.Id))
                throw new Exception("User already participate to the board.");

            Members.Add(user);
        }

        public void ChangeName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new Exception("Name null to change board's name.");

            Name = name;
        }

        public void ChangeDescription(string description) =>
            Description = description;
    }
}
