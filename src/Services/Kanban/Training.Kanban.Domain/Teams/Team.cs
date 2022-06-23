using System;
using System.Collections.Generic;
using System.Linq;
using Training.Core.Data.Repositories;
using Training.Core.Domain.Models;
using Training.Kanban.Domain.Boards;
using Training.Kanban.Domain.Users;

namespace Training.Kanban.Domain.Teams
{
    public class Team : Entity, IAggregateRoot
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int LeaderId { get; private set; }
        public User Leader { get; private set; }
        public ICollection<User> Members { get; private set; }
        public ICollection<Board> Boards { get; private set; }
        protected Team() { }

        public Team(string description, string name, User userLeader)
        {
            Description = description;
            Name = name;
            Leader = userLeader;
            LeaderId = userLeader.Id;

            Members = new List<User>() { userLeader };
            Boards = new List<Board>();
        }

        public void RemoveBoard(int boardId)
        {
            Board board = Boards.FirstOrDefault(b => 
                b.Id == boardId);

            if (board == null)
                throw new Exception("Board doesn't exists in this team.");

            if (board.Removed == true)
                throw new Exception("Board has already been removed.");

            board.ChangeRemoved(true);
        }

        public void AddBoard(Board board)
        {
            if (board == null)
                throw new ArgumentNullException(nameof(board));

            if (Boards.Any(b => b.Id == board.Id))
                throw new Exception("Board already exists in the team boards.");

            Boards.Add(board);
        }

        public void ChangeLeader(int userId)
        {
            if (userId <= 0)
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
            if (user == null)
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
