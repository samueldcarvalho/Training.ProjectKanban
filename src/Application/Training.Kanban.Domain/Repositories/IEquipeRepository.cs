using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Training.Kanban.Core.Data;
using Training.Kanban.Domain.Models.Entities;

namespace Training.Kanban.Domain.Repositories
{
    public interface IEquipeRepository : IRepository<Equipe>
    {
        Task<IEnumerable<Equipe>> ObterTodas();
        Task<Equipe> ObterPorId(int equipeId);
        Task<Usuario> ObterCriador(int usuarioId);
        Task<IEnumerable<Usuario>> ObterParticipantes(int equipeId);
        Task<IEnumerable<Quadro>> ObterQuadrosEquipe(int equipeId);
        Task<IEnumerable<Quadro>> ObterQuadrosEquipeDoUsuario(int equipeId, int usuarioId);

        void Adicionar(Equipe equipe);
        void Atualizar(Equipe equipe);

        void Adicionar(Quadro quadro);
        void Atualizar(Quadro quadro);
    }
}
