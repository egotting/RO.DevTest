using MediatR;
using RO.DevTest.Application.Features.User.Commands.CreateUserCommand.Request;
using RO.DevTest.Application.Features.User.Commands.CreateUserCommand.Response;

namespace RO.DevTest.Application.Features.User.Commands.CreateUserCommand.Handler.Interface;

public interface IGetUsersCommandHandler
{
    public Task<IEnumerable<GetUsersResult>> Handle();
}