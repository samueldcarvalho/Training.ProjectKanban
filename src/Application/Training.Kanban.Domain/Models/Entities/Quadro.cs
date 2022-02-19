using System;
using System.Collections.Generic;
using Training.Kanban.Core.Domain.Exceptions;
using Training.Kanban.Core.Models;

namespace Training.Kanban.Domain.Models.Entities
{
    public class Usuario
    {
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Nome { get; private set; }
        public DadosContato DadosContato { get; private set; }

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

    public class DadosContato
    {
        public string Email { get; private set; }
        public string Telefone { get; private set; }
        public bool AceitaWhatsapp { get; private set; }

        public DadosContato(string email, string telefone, bool aceitaWhatsapp)
        {
            Email = email;
            Telefone = telefone;
            AceitaWhatsapp = aceitaWhatsapp;

            Validar();
        }

        public void AlterarEmail(string email) => Email = Email;
        public void AlterarTelefone(string telefone) => Telefone = telefone;
        public void AlterarAceitacaoWhatsapp(bool aceita) => AceitaWhatsapp = aceita;

        private void Validar()
        {
            Validation.ValidaEmail(Email, "E-mail inválido");
            Validation.ValidarStringTamanho(Telefone, 10, 15, "Telefone inválido");
        }
    }










    public class Quadro : Entity
    {
        public string Nome { get; private set; }
        public string? Descricao { get; private set; }
        public Usuario Lider { get; private set; }
        public List<Usuario> Usuarios { get; set; }
        //public List<Lista>? Listas { get; private set; }

        public Quadro(string nome, string descricao, Equipe equipe, Usuario lider)
        {
            Nome = nome;
            Descricao = descricao;
            Lider = lider;
        }
    }
}
