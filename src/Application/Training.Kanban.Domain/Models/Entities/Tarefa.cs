using System;
using System.Collections.Generic;
using Training.Kanban.Core.Domain.Exceptions;
using Training.Kanban.Core.Domain.Interfaces;
using Training.Kanban.Core.Models;

namespace Training.Kanban.Domain.Models.Entities
{
    public class Tarefa : Entity, IAggregateRoot
    {
        public string Titulo { get; private set; }
        public string Descricao { get; private set; } = "";
        public Usuario Criador { get; private set; }
        public DateTime DataConclusao { get; private set; } = DateTime.MinValue;
        public ICollection<Usuario> Responsaveis { get; private set; }
        public ICollection<Interacao> Interacoes { get; private set; }
        public ICollection<Objetivo> Objetivos { get; private set; }

        public Tarefa(string titulo, string descricao, Usuario criador)
        {
            if (criador == null) throw new DomainException("Referência de criador nulo e não foi encontrado");

            Titulo = titulo;
            Descricao = descricao;
            Criador = criador;

            Validar();
        }

        private void Validar()
        {
            Validation.ValidarStringEspacoEVazio(Titulo, "O Titulo da tarefa não pode ser vazio.");
        }
    }
}
