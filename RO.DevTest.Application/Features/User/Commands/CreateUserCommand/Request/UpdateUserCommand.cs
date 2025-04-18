using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using RO.DevTest.Application.Features.User.Commands.CreateUserCommand.Response.General;

namespace RO.DevTest.Application.Features.User.Commands.CreateUserCommand.Request
{
    public class UpdateUserCommand : IRequest<GeneralResult<ResponseStatus.ResponseStatus>>
    {
        public string UserName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string CurrentPassword { get; set; } = string.Empty;

        public void AssignTo()
        {
            if (!string.IsNullOrWhiteSpace(UserName))
            {
                this.UserName = UserName;
            }

            if (!string.IsNullOrWhiteSpace(Name))
            {
                this.Name = Name;
            }
            if (!string.IsNullOrWhiteSpace(Email))
            {
                this.Email = Email;
            }
            if (!string.IsNullOrWhiteSpace(Password))
            {
                this.Password = Password;
            }
        }
    }
}