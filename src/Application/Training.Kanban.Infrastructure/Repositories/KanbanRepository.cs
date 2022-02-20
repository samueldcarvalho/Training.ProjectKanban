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

        public void Adicionar(Lista lista)
        {
            _context.Listas.Add(lista);
        }

        public void Adicionar(Quadro quadro)
        {
            _context.Quadros.Add(quadro);
        }

        public void Adicionar(Tarefa tarefa)
        {
            _context.Tarefas.Add(tarefa);
        }

        public void Atualizar(Quadro quadro)
        {
            _context.Quadros.Update(quadro);
        }

        public void Atualizar(Tarefa tarefa)
        {
            _context.Tarefas.Update(tarefa);
        }

        public void Atualizar(Lista lista)
        {
            _context.Listas.Update(lista);
        }

        public async Task<IEnumerable<Quadro>> ObterQuadrosPorEquipeIdUsuarioId(int equipeId, int usuarioId)
        {
            return await _context.Quadros.AsNoTracking().Where(q =>
                q.Criador.Id == usuarioId && q.Equipe.Id == equipeId).ToListAsync();
        }

        public async Task<IEnumerable<Quadro>> ObterQuadrosPorEquipeId(int equipeId)
        {
            return await _context.Quadros.AsNoTracking().Where(q =>
                q.Equipe.Id == equipeId).ToListAsync();
        }

        public async Task<IEnumerable<Lista>> ObterListasPorQuadroId(int quadroId)
        {
            return await _context.Listas.AsNoTracking().Where(li =>
                li.Quadro.Id == quadroId).ToListAsync();
        }
        public async Task<IEnumerable<Tarefa>> ObterTarefasPorListaId(int TarefaId)
        {
            return await _context.Tarefas.AsNoTracking().Where(t =>
                t.Id == TarefaId).ToListAsync();
        }
        public async Task<IEnumerable<Tarefa>> ObterTarefasPorListaIdUsuarioId(int tarefaId, int usuarioId)
        {
            return await _context.Tarefas.AsNoTracking().Where(t =>
                t.Id == tarefaId && t.Responsaveis.Any(user => 
                    user.Id == usuarioId)).ToListAsync();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
