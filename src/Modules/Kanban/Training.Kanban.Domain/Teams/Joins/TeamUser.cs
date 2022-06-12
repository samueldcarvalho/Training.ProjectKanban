using Training.Core.Domain.Models;
using Training.Kanban.Domain.Users;

namespace Training.Kanban.Domain.Teams.Joins
{
    public class TeamUser
    {
        public int TeamId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public Team Team { get; set; }
    }
}
