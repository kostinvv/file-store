using FileStore.Server.Errors;

namespace FileStore.Server.Results
{
    public class Result
    {
        private Result(List<Error> errors)
        {
            Errors = errors ?? [];
        }

        public bool IsSuccess => Errors.Count == 0;

        public IReadOnlyList<Error> Errors { get; }

        public static Result Success() => new([]);

        public static Result Failure(Error error) => new([error]);

        public static Result Failure(IEnumerable<Error> errors) => 
            new(new List<Error>(errors));
    }
}
