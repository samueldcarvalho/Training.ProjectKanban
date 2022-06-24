using MediatR;
using System;
using System.Threading.Tasks;

namespace Training.Core.CQRS.Models
{
    public abstract class Command<T> : IRequest<CommandResponse<T>>
    {
        public abstract bool IsValid();
    }
}
