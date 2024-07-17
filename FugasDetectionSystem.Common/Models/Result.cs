namespace FugasDetectionSystem.Common.Models
{
    public abstract class Result
    {
        public bool IsSuccess { get; }
        public string Message { get; }

        protected Result(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }

        public static SuccessResult Success(string message = null)
        {
            return new SuccessResult(message);
        }

        public static FailureResult Failure(string message)
        {
            return new FailureResult(message);
        }
    }
    public class Result<T> : Result
    {
        public T Value { get; }

        private Result(bool isSuccess, T value, string message) : base(isSuccess, message)
        {
            Value = value;
        }

        public static Result<T> Success(T value, string message = null)
        {
            return new Result<T>(true, value, message);
        }

        public static Result<T> Failure(string message)
        {
            return new Result<T>(false, default, message);
        }
    }
}
