using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Training.Kanban.Core.Data;
using Training.Kanban.Domain.Models.Entities;

namespace Training.Kanban.Infrastructure.Contexts
{
    class KanbanContext : DbContext, IUnitOfWork
    {
        public KanbanContext(DbContextOptions<KanbanContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseMySQL(Configuration.Configuration.DefaultConnection)
                .EnableSensitiveDataLogging()
                .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
        }
        public DbSet<Quadro> Quadros { get; set; }
        public DbSet<Lista> Listas { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }

        public async Task<bool> Commit()
        {
            throw new System.NotImplementedException();
        }
    }
}
