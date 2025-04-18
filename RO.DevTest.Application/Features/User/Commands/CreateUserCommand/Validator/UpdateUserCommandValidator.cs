using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using RO.DevTest.Application.Features.User.Commands.CreateUserCommand.Request;

namespace RO.DevTest.Application.Features.User.Commands.CreateUserCommand.Validator
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(cpau => cpau.Email)
                .NotNull()
                .NotEmpty()
                .WithMessage("O campo e-mail precisa ser preenchido");
            RuleFor(cpau => cpau.Email)
                .EmailAddress()
                .WithMessage("O campo e-mail precisa ser um e-mail válido");
            RuleFor(cpau => cpau.Password)
                .MinimumLength(6)
                .WithMessage("O campo senha precisa ter, pelo menos, 6 caracteres");
            RuleFor(cpau => cpau.CurrentPassword)
                .Matches(cpau => cpau.Password)
                .NotEmpty()
                .WithMessage("O campo precisa ser igual a senha atual");
        }
    }
}