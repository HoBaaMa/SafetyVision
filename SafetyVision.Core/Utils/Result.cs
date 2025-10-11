namespace SafetyVision.Core.Utils
{
    public class Result
    {
        public bool IsSuccess => Errors == null;
        public string[]? Errors { get; init; }
        protected Result() { }
        public static Result Success() => new Result() {};
        public static Result Failure(params string[] errors) => new Result() { Errors = errors };

    }
    public class Result<T> : Result
    {
        public T? Value { get; init; } = default;
        private Result() { }

        public static Result<T> Success(T value) => new Result<T> { Value = value };
        public static new Result<T> Failure(params string[] errors) => new Result<T> { Errors = errors };

        public static implicit operator Result<T>(T value) => Success(value);

    }
}
