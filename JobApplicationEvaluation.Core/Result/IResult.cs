namespace JobApplicationEvaluation.Core.Result
{
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }
    }
}
