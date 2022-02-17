using System;
using FluentValidation.Results;

namespace Training.Kanban.Core.Models
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public ValidationResult ValidationResult { get; protected set; }

        protected Entity()
        {
            ValidationResult = new ValidationResult();
        }

        public void AddValidationError(string error, string description)
        {
            ValidationResult.Errors.Add(new ValidationFailure(error, description));
        }

        public virtual bool IsValid()
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return Id.Equals(compareTo.Id);
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
