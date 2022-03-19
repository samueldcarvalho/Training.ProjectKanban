using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Core.Data.Repositories;
using Training.Kanban.Domain.Authentication.Models;

namespace Training.Kanban.Infraestructure.DataContexts.Authentication
{
    public class UserContext : DbContext, IUnitOfWork
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public Task<bool> Commit()
        {
            throw new NotImplementedException();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
                {
                    entity.HasIndex(e => e.Email).IsUnique();
                });
        }
    }
}
