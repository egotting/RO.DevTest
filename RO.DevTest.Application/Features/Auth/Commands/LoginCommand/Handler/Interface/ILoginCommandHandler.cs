using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace RO.DevTest.Application.Features.Auth.Commands.LoginCommand.Handler.Interface
{
    public interface ILoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
    {
        public Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken);
    }
}