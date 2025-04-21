using MediatR;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using RO.DevTest.Application.Features.User.Commands.CreateUserCommand.Handler.Interface;
using RO.DevTest.Application.Features.User.Commands.CreateUserCommand.Request;
using RO.DevTest.Application.ResultPattern;

namespace RO.DevTest.WebApi.Controllers;

[Route("api/user")]
[OpenApiTags("Users")]
public class UsersController(IMediator mediator, IGetUsersCommandHandler handler) : ControllerBase {
    private readonly IMediator _mediator = mediator;    
    private readonly IGetUsersCommandHandler _handler = handler;
    
    [HttpPost]
    public async Task<IResult> CreateUser( CreateUserCommand request) {
        var response = await _mediator.Send(request);
        
        return Results.Extensions.MapResult(response);
    }

    [HttpDelete]
    public async Task<IResult> DeleteUser(DeleteUserCommand request)
    {
        var response = await _mediator.Send(request);
        return Results.Extensions.MapResult(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var response = await _handler.Handle();
        return Ok(response);
    }
}
