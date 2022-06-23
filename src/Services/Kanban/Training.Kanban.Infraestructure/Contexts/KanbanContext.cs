using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Training.Core.Data.Repositories;
using Training.Kanban.Domain.Boards;
using Training.Kanban.Domain.Teams;
using Training.Kanban.Domain.Users;
using Training.Kanban.Infraestructure.Mappings;

namespace Training.Kanban.Infraestructure.Contexts
{
    public class KanbanContext : DbContext, IUnitOfWork
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Board> Boards { get; set; }

        public KanbanContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(KanbanContext).Assembly);
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
