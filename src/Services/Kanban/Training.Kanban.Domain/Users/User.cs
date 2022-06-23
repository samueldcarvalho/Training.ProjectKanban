using System;
using System.Collections.Generic;
using System.Linq;
using Training.Core.Data.Repositories;
using Training.Core.Domain.Models;
using Training.Kanban.Domain.Boards;
using Training.Kanban.Domain.Teams;

namespace Training.Kanban.Domain.Users
{
    public class User : Entity, IAggregateRoot
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Username {get; private set; }
        public string Password { get; private set; }
        public ICollection<Team> Teams { get; private set; }
        public ICollection<Board> Boards { get; private set; }
        
        protected User() { }
        public User(string name, string email, string username, string password = null)
        {
            Name = name;
            Email = email;
            Username = username;
            Password = password;
        }

        public void AddToTeam(Team team)
        {
            if (team == null)
                throw new ArgumentNullException(nameof(team));

            if (Teams.Any(t => t.Id == team.Id))
                throw new Exception("This user is already part of the team.");

            Teams.Add(team);
        }

        public void AddToBoard(Board board)
        {
            if (board == null)
                throw new ArgumentNullException(nameof(board));

            if (Boards.Any(b => b.Id == board.Id))
                throw new Exception("This user is already part of the board.");

            Boards.Add(board);
        }

        public void ChangeName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be null or empty", nameof(name));

            Name = name;
        }

        public void ChangeEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email cannot be null or empty", nameof(email));

            Email = email;
        }

        public void ChangePassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("New Password cannot be null or empty", nameof(password));

            Password = password;
        }
    }
}
