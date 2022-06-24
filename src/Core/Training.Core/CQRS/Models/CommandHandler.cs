using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Training.Core.CQRS.Models
{
    public abstract class CommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, CommandResponse<TResponse>> where TCommand : Command<TResponse>
    {
        public abstract Task<CommandResponse<TResponse>> Handle(TCommand request, CancellationToken cancellationToken);
    }
}
