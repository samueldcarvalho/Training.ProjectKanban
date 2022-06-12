using Microsoft.EntityFrameworkCore;
using Training.Authentication.API.Infraestructure.Mappings;
using Training.Core.Domain.Models;

namespace Training.Authentication.API.Infraestructure.Contexts
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
