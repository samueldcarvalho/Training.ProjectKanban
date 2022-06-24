using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Kanban.Domain.Boards;
using Training.Kanban.Domain.Teams;

namespace Training.Kanban.Application.Models.Views
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public IEnumerable<Board> Boards { get; set; } = Enumerable.Empty<Board>();
        public IEnumerable<Team> Teams { get; set; } = Enumerable.Empty<Team>();
        public IEnumerable<int> TeamLeaderIds { get; set; } = Enumerable.Empty<int>();
        public IEnumerable<int> BoardLeaderIds { get; set; } = Enumerable.Empty<int>();
    }
}
