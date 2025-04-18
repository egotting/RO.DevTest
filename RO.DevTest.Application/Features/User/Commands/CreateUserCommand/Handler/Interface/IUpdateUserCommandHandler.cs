using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using RO.DevTest.Application.Features.User.Commands.CreateUserCommand.Request;
using RO.DevTest.Application.Features.User.Commands.CreateUserCommand.Response.General;
using RO.DevTest.Domain.Enums;

namespace RO.DevTest.Application.Features.User.Commands.CreateUserCommand.Handler.Interface
{
    public interface IUpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, GeneralResult<ResponseStatus.ResponseStatus>>
    {
        public Task<GeneralResult<ResponseStatus.ResponseStatus>> Handle(UpdateUserCommand request, CancellationToken cancellationToken);

    }

}