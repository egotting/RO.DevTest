using MediatR;
using RO.DevTest.Application.Features.User.Commands.CreateUserCommand.Request;
using RO.DevTest.Application.ResultPattern;

namespace RO.DevTest.Application.Features.User.Commands.CreateUserCommand.Handler.Interface
{
    public interface IUpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Result<Error>>
    {
        public Task<Result<Error>> Handle(UpdateUserCommand request, CancellationToken cancellationToken);

    }

}