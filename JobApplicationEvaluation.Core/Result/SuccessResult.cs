namespace JobApplicationEvaluation.Core.Result
{
    public class SuccessResult : Result
    {
        public SuccessResult(string message, int statusCode) : base(true, message)
        {
            StatusCode = statusCode;
        }

        public SuccessResult() : base(true)
        {

        }
        public int StatusCode { get; }
    }
}
