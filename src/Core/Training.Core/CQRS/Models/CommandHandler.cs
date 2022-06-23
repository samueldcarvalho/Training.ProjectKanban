using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Training.Core.CQRS.Models
{
    public abstract class CommandHandler<T> : IRequestHandler<Command<T>, CommandResponse<T>>
    {
        public Task<CommandResponse<T>> Handle(Command<T> request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
