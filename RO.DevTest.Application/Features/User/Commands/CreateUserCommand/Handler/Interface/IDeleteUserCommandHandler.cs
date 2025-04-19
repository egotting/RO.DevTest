using MediatR;
using RO.DevTest.Application.Features.User.Commands.CreateUserCommand.Request;
using RO.DevTest.Application.ResultPattern;

namespace RO.DevTest.Application.Features.User.Commands.CreateUserCommand.Handler.Interface
{
    public interface IDeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Result<Error>>
    {
        public Task<Result<Error>> Handle(DeleteUserCommand request, CancellationToken cancellationToken);
    }

}