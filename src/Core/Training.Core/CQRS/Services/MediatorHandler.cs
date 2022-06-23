using MediatR;
using System.Threading.Tasks;
using Training.Core.CQRS.Models;

namespace Training.Core.CQRS.Services
{
    class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator) =>
            _mediator = mediator;
        

        public async Task<CommandResponse<T>> SendCommand<T>(Command<T> command)
        {
            var response = await _mediator.Send(command);

            return response;
        }
    }
}
