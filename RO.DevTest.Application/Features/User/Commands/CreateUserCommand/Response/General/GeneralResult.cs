using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RO.DevTest.Application.Features.User.Commands.CreateUserCommand.Response.General
{
    public class GeneralResult<T>
    {
        public T Response { get; set; }
        public string Status { get; set; } = string.Empty;


        public GeneralResult(T response, string status)
        {
            Response = response;
            Status = status;
        }
    }
}