using Microsoft.AspNetCore.Http;
using RO.DevTest.Application.ResultPattern.Enum;

namespace RO.DevTest.Application.ResultPattern;

public static class ResultExtension
{
    public static IResult MapResult<T>(this IResultExtensions resultExtension, Result<T> result)
    {
        if (result.IsSucess) return Results.Ok(result.Value);

        return GetErrorResults(result.Error);
    }

    internal static IResult GetErrorResults(Error error)
    {
        return error.Types switch
        {
            ErrorTypes.Validation => Results.BadRequest(error),
            ErrorTypes.NotFound => Results.NotFound(error),
            ErrorTypes.Conflict => Results.Conflict(error),
            _ => Results.Problem(
                statusCode: 500,
                title: "Server Failure",
                type: System.Enum.GetName(typeof(ErrorTypes), error.Types),
                extensions: new Dictionary<string, object?>
                {
                    { "errors", new[] { error } }
                })
        };
    }
}