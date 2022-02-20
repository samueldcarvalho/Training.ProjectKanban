using System.Collections.Generic;
using Training.Kanban.Core.Domain.Exceptions;
using Training.Kanban.Core.Domain.Interfaces;
using Training.Kanban.Core.Models;

namespace Training.Kanban.Domain.Models.Entities
{
    public class Quadro : Entity, IAggregateRoot
    {
        public string Titulo { get; private set; }
        public string Descricao { get; private set; } = "";
        public Equipe Equipe { get; private set; }
        public Usuario Criador { get; private set; }
        public ICollection<Usuario> Usuarios { get; private set; }
        public ICollection<Lista> Listas { get; private set; }

        public Quadro(string titulo, string descricao)
        {
            Titulo = titulo;
            Descricao = descricao;

            Validar();
        }

        private void Validar()
        {
            Validation.ValidarStringTamanhoMinimo(Titulo, 3, "Não é possível inserir uma equipe com título menor que 3 caracteres.");
        }
    }
}
