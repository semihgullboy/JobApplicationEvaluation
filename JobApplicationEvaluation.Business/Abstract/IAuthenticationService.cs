using JobApplicationEvaluation.Core.Result;

namespace JobApplicationEvaluation.Business.Abstract
{
    public interface IAuthenticationService
    {
        Task<IResult> Login(string email, string password);
    }
}
