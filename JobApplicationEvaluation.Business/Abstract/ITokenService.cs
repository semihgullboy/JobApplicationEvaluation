using JobApplicationEvaluation.Core.Result;
using JobApplicationEvaluation.ViewModels.BaseViewModel;
using System.Security.Claims;

namespace JobApplicationEvaluation.Business.Abstract
{
    public interface ITokenService
    {
        string GenerateToken(List<Claim> authClaims);
        bool IsTokenValid(string token);
        Task<IDataResult<UserBaseViewModel>> GetUserInfoFromToken();
    }
}
