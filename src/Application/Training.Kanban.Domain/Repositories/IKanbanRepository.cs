using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Training.Kanban.Core.Data;
using Training.Kanban.Domain.Models.Entities;

namespace Training.Kanban.Domain.Repositories
{
    public interface IKanbanRepository : IRepository<Equipe>
    {
        Task<IEnumerable<Quadro>> ObterQuadrosPorEquipeId(int equipeId);
        Task<IEnumerable<Quadro>> ObterQuadrosPorEquipeIdUsuarioId(int equipeId, int usuarioId);

        Task<IEnumerable<Lista>> ObterListasPorQuadroId(int quadroId);

        Task<IEnumerable<Tarefa>> ObterTarefasPorListaId(int TarefaId);
        Task<IEnumerable<Tarefa>> ObterTarefasPorListaIdUsuarioId(int TarefaId, int usuarioId);

        void Adicionar(Quadro quadro);
        void Atualizar(Quadro quadro);

        void Adicionar(Lista lista);
        void Atualizar(Lista lista);

        void Adicionar(Tarefa tarefa);
        void Atualizar(Tarefa tarefa);
    }
}
