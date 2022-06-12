using Microsoft.EntityFrameworkCore;
using Training.Core.Domain.Models;
using Training.Kanban.Infraestructure.Mappings;

namespace Training.Kanban.Infraestructure.Contexts
{
    public class AuthenticationContext : DbContext
    {
        public AuthenticationContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMappings());
        }

        public DbSet<User> Users { get; set; }
    }
}
