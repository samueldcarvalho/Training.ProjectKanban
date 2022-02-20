using System;
using System.ComponentModel.DataAnnotations;
using FluentValidation.Results;

namespace Training.Kanban.Core.Models
{
    public abstract class Entity
    {
        [Key()]
        public int Id { get; private set; }
        public string Situacao { get; private set; }
        public FluentValidation.Results.ValidationResult ValidationResult { get; protected set; }

        protected Entity()
        {
            ValidationResult = new FluentValidation.Results.ValidationResult();
            Situacao = "ATIVO";
        }

        public void AddValidationError(string error, string description)
        {
            ValidationResult.Errors.Add(new ValidationFailure(error, description));
        }

        public void Ativar() => Situacao = "ATIVO";
        public void Inativar() => Situacao = "INATIVO";

        public override bool Equals(object obj)
        {
            var comparteTo = obj as Entity;

            if (ReferenceEquals(this, comparteTo)) return true;
            if (ReferenceEquals(null, comparteTo)) return false;

            return Id.Equals(comparteTo.Id);
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }
    }
}
