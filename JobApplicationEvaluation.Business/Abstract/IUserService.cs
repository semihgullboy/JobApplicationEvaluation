using JobApplicationEvaluation.Core.Result;
using JobApplicationEvaluation.ViewModels.RequestViewModel.User;

namespace JobApplicationEvaluation.Business.Abstract
{
    public interface IUserService
    {
        Task<IResult> CreateUserAsync(CreateUserRequestViewModel model);
    }
}
