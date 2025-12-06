namespace JobApplicationEvaluation.Core.Result
{
    public interface IDataResult<T> : IResult where T : class
    {
        T Data { get; }
    }
}
