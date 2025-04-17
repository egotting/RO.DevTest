using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RO.DevTest.Application.Features.User.Commands.CreateUserCommand.Response
{
    public record DeleteUserResult
    {
        public string Status { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public DeleteUserResult()
        {

        }

        public DeleteUserResult(string status, string email)
        {
            Status = status;
            Email = email;
        }
    }
}