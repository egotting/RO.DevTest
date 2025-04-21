using FluentValidation.Results;
using MediatR;
using RO.DevTest.Application.Contracts.Infrastructure;
using RO.DevTest.Application.Features.User.Commands.CreateUserCommand.Request;
using RO.DevTest.Application.Features.User.Commands.CreateUserCommand.Validator;
using RO.DevTest.Application.ResultPattern;

namespace RO.DevTest.Application.Features.User.Commands.CreateUserCommand.Handler.Interface;

public class DeleteUserCommandHandler(IIdentityAbstractor identityAbstractor) : IDeleteUserCommandHandler
{
    private readonly IIdentityAbstractor _identityAbstractor = identityAbstractor;


    public async Task<Result<Error>> Handle(DeleteUserCommand request,
        CancellationToken cancellationToken)
    {
        DeleteUserCommandValidator validator = new();
        ValidationResult validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid) return Result<Error>.Failure(Error.Validation("User.Not.Valid", "User invalid."));

        var findUser = await _identityAbstractor.FindUserByIdAsync(request.Email);

        if (!findUser.EmailConfirmed) return Result<Error>.Failure(Error.NotFound("User.NotFound", "Not found user email."));

        await _identityAbstractor.DeleteUser(findUser);

        return Result<Error>.Sucess(Error.Success("User.Deleted", "A user account was deleted."));
    }

}