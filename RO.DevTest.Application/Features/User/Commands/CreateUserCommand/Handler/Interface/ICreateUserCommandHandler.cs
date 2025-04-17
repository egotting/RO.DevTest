using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace RO.DevTest.Application.Features.User.Commands.CreateUserCommand.Handler
{
    public interface ICreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserResult>
    {
        public Task<CreateUserResult> Handle(CreateUserCommand request, CancellationToken cancellationToken);
    }
}