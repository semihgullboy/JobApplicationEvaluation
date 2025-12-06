namespace JobApplicationEvaluation.Core.Result
{
    public class ErrorDataResult<T> : DataResult<T> where T : class
    {
        public ErrorDataResult(T data, string message, int statusCode)
            : base(data, false, message)
        {
            StatusCode = statusCode;
        }

        public ErrorDataResult(T data, int statusCode)
            : base(data, false)
        {
            StatusCode = statusCode;
        }

        public ErrorDataResult(string message, int statusCode)
            : base(default, false, message)
        {
            StatusCode = statusCode;
        }

        public ErrorDataResult(int statusCode)
            : base(default, false)
        {
            StatusCode = statusCode;
        }

        public int StatusCode { get; }
    }
}
