using MediatR;
using RO.DevTest.Application.Features.User.Commands.CreateUserCommand.Response.General;

namespace RO.DevTest.Application.Features.User.Commands.CreateUserCommand.Handler.Interface
{
    public interface ICreateUserCommandHandler : IRequestHandler<Request.CreateUserCommand, GeneralResult<ResponseStatus.ResponseStatus>>
    {
        public Task<GeneralResult<ResponseStatus.ResponseStatus>> Handle(Request.CreateUserCommand request, CancellationToken cancellationToken);
    }

}