using System.Collections.Generic;
using Training.Kanban.Core.Domain.Exceptions;
using Training.Kanban.Core.Domain.Interfaces;
using Training.Kanban.Core.Models;

namespace Training.Kanban.Domain.Models.Entities
{
    public class Equipe : Entity, IAggregateRoot
    {
        public string Nome { get; private set; }
        public string? Descricao { get; private set; }
        public int CriadorId { get; private set; }

        public Usuario Criador { get; private set; }
        public List<Quadro> Quadros { get; private set; }
        public List<Usuario> Usuarios { get; private set; }

        public Equipe(string nome, string descricao, int criadorId)
        {
            Nome = nome;
            Descricao = descricao;
            CriadorId = criadorId;

            Validar();
        }

        public void AlterarNome(string nome) => Nome = nome;
        public void AlterarDescricao(string descricao) => Descricao = descricao;

        public void Validar()
        {
            Validation.ValidarStringEspacoEVazio(Nome, "Não é possível inserir uma equipe com nome vazio");
            Validation.ValidarStringTamanhoMaximo(Nome, 30, "Não é possível gravar uma equipe com nome contendo mais que 30 caracteres");
            Validation.ValidarMinimo(CriadorId, 1, "Criador com código menor ou igual a zero");
        }
    }
}
