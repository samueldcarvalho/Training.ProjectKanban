using System;
using FluentValidation.Results;

namespace Training.Kanban.Core.Models
{
    public abstract class Entity
    {
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
    }
}
