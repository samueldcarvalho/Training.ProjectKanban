using System;
using System.Collections.Generic;
using Training.Kanban.Core.Domain.Exceptions;
using Training.Kanban.Core.Models;

namespace Training.Kanban.Domain.Models.Entities
{
    public class Quadro : Entity
    {
        public string Titulo { get; private set; }
        public string? Descricao { get; private set; }
        public int CriadorId { get; private set; }
        public int EquipeId { get; set; }

        public Equipe Equipe { get; set; }
        public Usuario Criador { get; set; }
        public List<Usuario> Usuarios { get; set; }
        public List<Lista>? Listas { get; set; }

        public Quadro(string titulo, string descricao, int criadorId, int equipeId)
        {
            Titulo = titulo;
            Descricao = descricao;
            CriadorId = criadorId;
            EquipeId = equipeId;

            Validar();
        }

        private void Validar()
        {
            Validation.ValidarStringTamanhoMinimo(Titulo, 3, "Não é possível inserir uma equipe com título menor que 3 caracteres.");
            Validation.ValidarMinimo(CriadorId, 1, "Código de Criador Inválido");
            Validation.ValidarMinimo(EquipeId, 1, "Código de Equipe Inválida");
        }
    }

    public class Lista
    {
        public string Titulo { get; private set; }
        public string? Descricao { get; private set; }
        public int CriadorId { get; private set; }

        public Usuario Criador { get; set; }
        public List<Tarefa> Tarefas { get; set; }
    }

    public class Tarefa
    {
    }
}
