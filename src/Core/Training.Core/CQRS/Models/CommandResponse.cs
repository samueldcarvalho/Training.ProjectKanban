using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Core.CQRS.Models
{
    public class CommandResponse<T>
    {
        public ValidationResult ValidationResult { get; private set; }
        public T Result { get; private set; }

        public CommandResponse(ValidationResult validationResult, T result)
        {
            ValidationResult = validationResult;
            Result = result;
        }
    }
}
