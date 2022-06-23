using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Training.Core.Data.Repositories;
using Training.Kanban.Domain.Boards;
using Training.Kanban.Domain.Teams;
using Training.Kanban.Domain.Users;
using Training.Kanban.Infraestructure.Mappings;

namespace Training.Kanban.Infraestructure.Contexts
{
    public class KanbanDbContext : DbContext, IUnitOfWork
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Board> Boards { get; set; }

        public KanbanDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMappings());
            modelBuilder.ApplyConfiguration(new TeamMappings());
            modelBuilder.ApplyConfiguration(new BoardMappings());

            base.OnModelCreating(modelBuilder);
        }

        public Task<bool> Commit()
        {
            if(!ChangeTracker.HasChanges())
                return Task.FromResult(false);

            SaveChanges();
            return Task.FromResult(true);
        }
    }
}
