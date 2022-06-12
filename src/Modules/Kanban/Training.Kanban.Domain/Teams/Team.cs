using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Core.Domain.Models;
using Training.Kanban.Domain.Boards;

namespace Training.Kanban.Domain.Teams
{
    public class Team : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public User Leader { get; private set; }
        public ICollection<User> Users { get; private set; }
        public ICollection<Board> Boards { get; private set; }
    }
}
