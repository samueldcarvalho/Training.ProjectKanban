using System.Collections.Generic;
using Training.Kanban.Core.Domain.Exceptions;
using Training.Kanban.Core.Domain.Interfaces;
using Training.Kanban.Core.Models;

namespace Training.Kanban.Domain.Models.Entities
{
    public class Usuario : Entity, IAggregateRoot
    {
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Nome { get; private set; }
        public DadosContato DadosContato { get; private set; }
        public ICollection<Equipe> Equipes { get; private set; }
        public ICollection<Quadro> Quadros { get; private set; }
        public ICollection<Tarefa> Tarefas { get; set; }
        public ICollection<Interacao> Interacoes { get; private set; }
        public ICollection<Objetivo> Objetivos { get; private set; }

        public Usuario(string username, string password, string nome, DadosContato dadosContato)
        {
            Username = username;
            Password = password;
            Nome = nome;
            DadosContato = dadosContato;

            Validar();
        }

        private void Validar()
        {
            Validation.ValidarStringEspacoEVazio(Username, "Usuário inválido");
            Validation.ValidarStringEspacoEVazio(Password, "Senha inválida");
            Validation.ValidarStringTamanho(Nome, 3, 40, "Nome inválido");
        }
    }
}
