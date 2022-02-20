using System;
using System.Collections.Generic;
using Training.Kanban.Core.Domain.Exceptions;
using Training.Kanban.Core.Models;
using Training.Kanban.Domain.Models.Enumerators;

namespace Training.Kanban.Domain.Models.Entities
{
    public class Lista : Entity
    {
        public string Titulo { get; private set; }
        public string Descricao { get; private set; } = "";
        public Usuario Criador { get; private set; }
        public Quadro Quadro { get; private set; }
        public ICollection<Tarefa> Tarefas { get; private set; }

        public Lista(string titulo, string descricao)
        {
            Titulo = titulo;
            Descricao = descricao;

            Validar();
        }

        private void Validar()
        {
            Validation.ValidarStringEspacoEVazio(Titulo, "Título da lista inválido");
        }
    }

    public class Interacao : Entity
    {
        public TipoInteracaoEnum TipoInteracao { get; private set; }
        public string Descricao { get; private set; } = "";
        public string Mensagem { get; private set; }
        public Usuario Responsavel { get; private set; }
        public Tarefa Tarefa { get; private set; }
        public ICollection<Usuario> Mencionados { get; private set; }
    }
}
