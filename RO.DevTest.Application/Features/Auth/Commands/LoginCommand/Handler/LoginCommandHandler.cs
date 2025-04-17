using MediatR;
using RO.DevTest.Application.Features.Auth.Commands.LoginCommand.Handler.Interface;

namespace RO.DevTest.Application.Features.Auth.Commands.LoginCommand;

public class LoginCommandHandler : ILoginCommandHandler
{
    public Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        ///[TODO] - CREATE LOGIN HANDLER HERE    

        throw new NotImplementedException();
    }
}
