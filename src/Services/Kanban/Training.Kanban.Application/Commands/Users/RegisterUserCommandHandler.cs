using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Training.Core.CQRS.Models;
using Training.Kanban.Domain.Interfaces;
using Training.Kanban.Domain.Users;

namespace Training.Kanban.Application.Commands.Users
{
    public class RegisterUserCommandHandler : CommandHandler<RegisterUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;

        public RegisterUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public override async Task<CommandResponse<bool>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return new CommandResponse<bool>(false);

            try
            {
                await _userRepository.Add(new User(request.Name, request.Email, request.Username, request.Password));
                await _userRepository.UnitOfWork.Commit();

                return new CommandResponse<bool>(true);
            }
            catch
            {
                return new CommandResponse<bool>(false);
            }
        }
    }
}
