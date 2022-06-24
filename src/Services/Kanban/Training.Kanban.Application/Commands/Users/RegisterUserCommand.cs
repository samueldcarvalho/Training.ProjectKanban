using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Core.CQRS.Models;

namespace Training.Kanban.Application.Commands.Users
{
    public class RegisterUserCommand : Command<bool>
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public RegisterUserCommand(string name, string email, string username, string password)
        {
            Name = name;
            Email = email;
            Username = username;
            Password = password;
        }
        public override bool IsValid()
        {
            bool IsValid = new RegisterNewUserCommandValidation().Validate(this).IsValid;
            return IsValid;
        }
    }

    public class RegisterNewUserCommandValidation : AbstractValidator<RegisterUserCommand>
    {
        public RegisterNewUserCommandValidation()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email is null or empty.");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is null or empty");

            RuleFor(x => x.Username)
                .NotEmpty()
                .WithMessage("Username is null or empty");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Name is null or empty");
        }
    }
}
