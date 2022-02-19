using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Linq;
using System.Threading.Tasks;
using Training.Kanban.Core.Data;
using Training.Kanban.Domain.Models.Entities;

namespace Training.Kanban.Infrastructure.Contexts
{
    class KanbanContext : DbContext, IUnitOfWork
    {
        //public KanbanContext(DbContextOptions<KanbanContext> options) : base(options)
        //{

        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string strConnection = "Data source=()";
        }

        public DbSet<Equipe> Equipes { get; set; }
        public DbSet<Quadro> Quadros { get; set; }

        public Task<bool> Commit()
        {
            throw new System.NotImplementedException();
        }
    }
}
