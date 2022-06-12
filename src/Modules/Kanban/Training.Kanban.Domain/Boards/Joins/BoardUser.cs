using Training.Core.Domain.Models;
using Training.Kanban.Domain.Users;

namespace Training.Kanban.Domain.Boards.Joins
{
    public class BoardUser
    {
        public int BoardId { get; set; }
        public int UserId { get; set; }
        public Board Board { get; set; }
        public User User { get; set; }
    }
}
