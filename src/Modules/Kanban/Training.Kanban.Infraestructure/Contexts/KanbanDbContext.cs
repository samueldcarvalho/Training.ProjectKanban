using Microsoft.EntityFrameworkCore;
using Training.Kanban.Domain.Boards;
using Training.Kanban.Domain.Teams;
using Training.Kanban.Domain.Users;
using Training.Kanban.Infraestructure.Mappings;

namespace Training.Kanban.Infraestructure.Contexts
{
    public class KanbanDbContext : DbContext
    {
        public KanbanDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMappings());
            modelBuilder.ApplyConfiguration(new TeamMappings());
            modelBuilder.ApplyConfiguration(new BoardMappings());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Board> Boards { get; set; }

    }
}
