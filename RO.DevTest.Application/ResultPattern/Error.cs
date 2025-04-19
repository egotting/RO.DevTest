using RO.DevTest.Application.ResultPattern.Enum;

namespace RO.DevTest.Application.ResultPattern;

public record Error()
{
    public static readonly Error None = new(string.Empty, string.Empty, ErrorTypes.Failure);

    public Error(string code, string description, ErrorTypes types) : this()
    {
        Code = code;
        Description = description ?? string.Empty;
        Types = types;
    }


    public string Code { get; set; }
    public string Description { get; set; }
    public ErrorTypes Types { get; set; }


    public static Error Failure(string code, string description) =>
        new(code, description, ErrorTypes.Failure);

    public static Error Success(string code, string description)
        => new(code, description, ErrorTypes.Success);

    public static Error NotFound(string code, string description)
        => new(code, description, ErrorTypes.NotFound);

    public static Error Conflict(string code, string description)
        => new(code, description, ErrorTypes.Conflict);

    public static Error Validation(string code, string description)
        => new(code, description, ErrorTypes.Conflict);
};