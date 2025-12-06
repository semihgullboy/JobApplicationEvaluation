using System.Net;

namespace JobApplicationEvaluation.Core.Result
{
    public class SuccessDataResult<T> : DataResult<T> where T : class
    {
        public int StatusCode { get; } = (int)HttpStatusCode.OK;
        public SuccessDataResult(T data, string message) : base(data, true, message)
        { }
        public SuccessDataResult(T data) : base(data, true)
        { }
        public SuccessDataResult(string message) : base(default, true, message)
        { }
    }
}
