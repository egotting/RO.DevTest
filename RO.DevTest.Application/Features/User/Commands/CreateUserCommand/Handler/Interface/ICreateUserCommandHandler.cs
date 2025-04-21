using MediatR;
using RO.DevTest.Application.ResultPattern;

namespace RO.DevTest.Application.Features.User.Commands.CreateUserCommand.Handler.Interface
{
    public interface ICreateUserCommandHandler :IRequestHandler<Request.CreateUserCommand, Result<Error>>
    {
    }

}