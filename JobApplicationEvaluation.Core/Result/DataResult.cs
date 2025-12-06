namespace JobApplicationEvaluation.Core.Result
{
    public class DataResult<T> : Result, IDataResult<T> where T : class
    {
        public DataResult(T data, bool success, string message) : base(success, message)
        {
            Data = data;
        }

        public DataResult(T data, bool success) : base(success)
        {
            Data = data;
        }
        public T Data { get; }
    }
}
