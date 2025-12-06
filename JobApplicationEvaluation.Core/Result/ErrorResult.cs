namespace JobApplicationEvaluation.Core.Result
{
    public class ErrorResult : Result
    {
        public int StatusCode { get; }

        public ErrorResult(string message, int statusCode) : base(false, message)
        {
            StatusCode = statusCode;
        }
        public ErrorResult(string message) : base(false, message)
        { }
        public ErrorResult() : base(false)
        { }
    }
}
