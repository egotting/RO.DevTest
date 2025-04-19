namespace RO.DevTest.Application.ResultPattern
{
    public class Result<T>
    {
        public Result(T value)
        {
            IsSucess = true;
            Value = value;
            Error = Error.None;
        }

        public Result(Error error)
        {
            IsSucess = false;
            Error = error;
        }

        public bool IsSucess { get; }
        public T? Value { get; }
        public Error Error { get; }

        public static Result<T> Sucess(T value) => new(value);
        public static Result<T> Failure(Error error) => new(error);
    }
}