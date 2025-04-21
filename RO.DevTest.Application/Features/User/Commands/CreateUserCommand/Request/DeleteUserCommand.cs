using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using RO.DevTest.Application.ResultPattern;
using RO.DevTest.Domain.Enums;

namespace RO.DevTest.Application.Features.User.Commands.CreateUserCommand.Request
{
    public class DeleteUserCommand : IRequest<Result<Error>>
    {
        public DeleteUserCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public DeleteUserCommand() { }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

    }
}