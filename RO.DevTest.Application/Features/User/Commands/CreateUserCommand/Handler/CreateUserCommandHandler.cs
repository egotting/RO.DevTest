using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using RO.DevTest.Application.Contracts.Infrastructure;
using RO.DevTest.Application.Features.User.Commands.CreateUserCommand.Handler.Interface;
using RO.DevTest.Application.Features.User.Commands.CreateUserCommand.Validator;
using RO.DevTest.Application.ResultPattern;
using RO.DevTest.Domain.Exception;

namespace RO.DevTest.Application.Features.User.Commands.CreateUserCommand.Handler;

/// <summary>
/// Command handler for the creation of <see cref="Domain.Entities.User"/>
/// </summary>
public class CreateUserCommandHandler(IIdentityAbstractor identityAbstractor) : ICreateUserCommandHandler
{
    private readonly IIdentityAbstractor _identityAbstractor = identityAbstractor;

    public async Task<Result<Error>> Handle(Request.CreateUserCommand request, CancellationToken cancellationToken)
    {
        CreateUserCommandValidator validator = new();
        ValidationResult validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            return Result<Error>.Failure(Error.Validation("User.Not.Valid", 
                "User invalid."));
        }

        Domain.Entities.User newUser = request.AssignTo();
        IdentityResult userCreationResult = await _identityAbstractor.CreateUserAsync(newUser, request.Password);
        if (!userCreationResult.Succeeded)
        {
            return Result<Error>.Failure(Error.Validation("User.Error.Creation",
                "Error when try to create account"));
        }

        IdentityResult userRoleResult = await _identityAbstractor.AddToRoleAsync(newUser, request.Role);
        if (!userRoleResult.Succeeded)
        {
            return Result<Error>.Failure(Error.Validation("Error.Put.Role",
                "Error when try to put the role"));
        }

        return Result<Error>.Sucess(Error.Success("User.Created", "Account created successfully"));   
    }
}