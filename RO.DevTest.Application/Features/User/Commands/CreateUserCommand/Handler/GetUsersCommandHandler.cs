using FluentValidation.Results;
using MediatR;
using RO.DevTest.Application.Contracts.Infrastructure;
using RO.DevTest.Application.Contracts.Persistance.Repositories;
using RO.DevTest.Application.Features.User.Commands.CreateUserCommand.Handler.Interface;
using RO.DevTest.Application.Features.User.Commands.CreateUserCommand.Request;
using RO.DevTest.Application.Features.User.Commands.CreateUserCommand.Response;
using RO.DevTest.Application.Features.User.Commands.CreateUserCommand.Validator;
using RO.DevTest.Application.ResultPattern;

namespace RO.DevTest.Application.Features.User.Commands.CreateUserCommand.Handler;

public class GetUsersCommandHandler(IUserRepository userRepository)
    : IGetUsersCommandHandler
{
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<IEnumerable<GetUsersResult>> Handle()
    {

        var users = await userRepository.GetAll();
        return users.Select(user => new GetUsersResult
        {
            UserName = user.UserName!,
            Email = user.Email!,
            Name = user.Name,
        });
    }
}