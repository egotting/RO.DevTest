using MediatR;
using RO.DevTest.Application.Features.User.Commands.CreateUserCommand.Request;
using RO.DevTest.Application.Features.User.Commands.CreateUserCommand.Response.General;

namespace RO.DevTest.Application.Features.User.Commands.CreateUserCommand.Handler.Interface
{
    public interface IDeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, GeneralResult<ResponseStatus.ResponseStatus>>
    {
        public Task<GeneralResult<ResponseStatus.ResponseStatus>> Handle(DeleteUserCommand request, CancellationToken cancellationToken);
    }

}