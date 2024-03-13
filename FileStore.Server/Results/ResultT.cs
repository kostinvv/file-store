using FileStore.Server.Errors;

namespace FileStore.Server.Results
{
    public class Result<TValue>
    {
        private Result(List<Error> errors, TValue value)
        {
            Errors = errors ?? [];
            Value = value;
        }

        public TValue? Value { get; }
        public bool IsSuccess => Errors.Count == 0;

        public IReadOnlyList<Error> Errors { get; }

        public static Result<TValue> Success(TValue value) => new([], value);

        public static Result<TValue> Failure(Error error) => new([error], default!);

        public static Result<TValue> Failure(IEnumerable<Error> errors) =>
            new(new List<Error>(errors), default!);
    }
}
