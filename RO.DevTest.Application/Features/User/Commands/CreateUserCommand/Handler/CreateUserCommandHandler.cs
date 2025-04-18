using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using RO.DevTest.Application.Contracts.Infrastructure;
using RO.DevTest.Application.Features.User.Commands.CreateUserCommand.Handler.Interface;
using RO.DevTest.Application.Features.User.Commands.CreateUserCommand.Response.General;
using RO.DevTest.Application.Features.User.Commands.CreateUserCommand.Validator;
using RO.DevTest.Domain.Exception;

namespace RO.DevTest.Application.Features.User.Commands.CreateUserCommand.Handler;

/// <summary>
/// Command handler for the creation of <see cref="Domain.Entities.User"/>
/// </summary>
public class CreateUserCommandHandler(IIdentityAbstractor identityAbstractor) : ICreateUserCommandHandler
{
    private readonly IIdentityAbstractor _identityAbstractor = identityAbstractor;

    public async Task<GeneralResult<ResponseStatus.ResponseStatus>> Handle(Request.CreateUserCommand request, CancellationToken cancellationToken)
    {
        CreateUserCommandValidator validator = new();
        ValidationResult validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new BadRequestException(validationResult);
        }

        Domain.Entities.User newUser = request.AssignTo();
        IdentityResult userCreationResult = await _identityAbstractor.CreateUserAsync(newUser, request.Password);
        if (!userCreationResult.Succeeded)
        {
            return new GeneralResult<ResponseStatus.ResponseStatus>(ResponseStatus.ResponseStatus.ERROR, "Error when try to create account");
            // throw new BadRequestException(userCreationResult);
        }

        IdentityResult userRoleResult = await _identityAbstractor.AddToRoleAsync(newUser, request.Role);
        if (!userRoleResult.Succeeded)
        {
            return new GeneralResult<ResponseStatus.ResponseStatus>(ResponseStatus.ResponseStatus.ERROR, "Error when try to put the role");
            // throw new BadRequestException(userRoleResult);
        }

        return new GeneralResult<ResponseStatus.ResponseStatus>(ResponseStatus.ResponseStatus.SUCESS, "Account created successfully");
    }
}
