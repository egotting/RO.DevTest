using MediatR;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using RO.DevTest.Application.Features.User.Commands.CreateUserCommand;
using RO.DevTest.Application.Features.User.Commands.CreateUserCommand.Request;
using RO.DevTest.Application.Features.User.Commands.CreateUserCommand.Response;

namespace RO.DevTest.WebApi.Controllers;

[Route("api/user")]
[OpenApiTags("Users")]
public class UsersController(IMediator mediator) : ControllerBase {
    private readonly IMediator _mediator = mediator;

    
    [HttpPost]
    [ProducesResponseType(typeof(CreateUserResult), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(CreateUserResult), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateUser( CreateUserCommand request) {
        var response = await _mediator.Send(request);
        
        return Created(HttpContext.Request.GetDisplayUrl(), response);
    }
}
