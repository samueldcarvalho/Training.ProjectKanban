using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Kanban.Core.Data;
using Training.Kanban.Domain.Models.Entities;
using Training.Kanban.Domain.Repositories;
using Training.Kanban.Infrastructure.Contexts;

namespace Training.Kanban.Infrastructure.Repositories
{
    class KanbanRepository : IKanbanRepository
    {
        private readonly KanbanContext _context;
        public IUnitOfWork UnitOfWork => _context;
        public KanbanRepository(KanbanContext context)
        {
            _context = context;
        }

        public void Adicionar(Equipe equipe)
        {
            _context.Equipes.Add(equipe);
        }

        public void Adicionar(Quadro quadro)
        {
            _context.Quadros.Add(quadro);
        }

        public void Atualizar(Equipe equipe)
        {
            _context.Equipes.Update(equipe);
        }

        public void Atualizar(Quadro quadro)
        {
            _context.Quadros.Update(quadro);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task<Equipe> ObterPorId(int equipeId)
        {
            return await _context.Equipes.AsNoTracking().FirstOrDefaultAsync(e =>
                e.Id == equipeId);
        }

        public async Task<IEnumerable<Quadro>> ObterQuadrosPorEquipeIdUsuarioId(int equipeId, int usuarioId)
        {
            return await _context.Quadros.AsNoTracking().Where(q =>
                q.CriadorId == usuarioId && q.EquipeId == equipeId).ToListAsync();
        }

        public async Task<IEnumerable<Equipe>> ObterTodas()
        {
            return await _context.Equipes.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Quadro>> ObterQuadrosPorEquipeId(int equipeId)
        {
            return await _context.Quadros.AsNoTracking().Where(q => 
                q.EquipeId == equipeId).ToListAsync();
        }
    }
}
