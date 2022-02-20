using System;
using System.Collections.Generic;
using Training.Kanban.Core.Domain.Exceptions;
using Training.Kanban.Core.Models;

namespace Training.Kanban.Domain.Models.Entities
{
    public class Objetivo : Entity
    {
        public string Descricao { get; set; } = "";
        public ICollection<Usuario> Responsaveis { get; private set; }
        public DateTime DataConclusao { get; private set; }
        public Tarefa Tarefa { get; private set; }

        public Objetivo(string descricao, ICollection<Usuario> responsaveis, Tarefa tarefa)
        {
            Descricao = descricao;
            Responsaveis = responsaveis;
            Tarefa = tarefa;

            Validar();
        }

        private void Validar()
        {
            Validation.ValidarStringEspacoEVazio(Descricao, "A Descrição é obrigatória.");
        }
    }
}
