using JobApplicationEvaluation.Core.Result;
using JobApplicationEvaluation.ViewModels.BaseViewModel;
using JobApplicationEvaluation.ViewModels.RequestViewModel.User;

namespace JobApplicationEvaluation.Business.Abstract
{
    public interface IUserService
    {
        Task<IResult> CreateUserAsync(CreateUserRequestViewModel model);
        Task<IDataResult<UserBaseViewModel>> GetUserByGuidIdAsync(string guid);
    }
}
