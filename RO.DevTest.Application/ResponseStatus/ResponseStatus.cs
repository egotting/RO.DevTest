
namespace RO.DevTest.Application.ResponseStatus
{
    public sealed class ResponseStatus(string value)
    {
        public static readonly ResponseStatus SUCESS = new ResponseStatus("Sucess");
        public static readonly ResponseStatus WARNING = new ResponseStatus("Warning");
        public static readonly ResponseStatus ERROR = new ResponseStatus("Error");
        public static readonly ResponseStatus INFO = new ResponseStatus("Info");

        public string Value { get; } = value;

        public override string ToString() => Value;

    }
}