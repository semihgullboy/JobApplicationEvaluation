using JobApplicationEvaluation.Business.Abstract;
using JobApplicationEvaluation.ViewModels.BaseViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobApplicationEvaluation.Api.Controllers
{
    [Authorize]
    public class BaseController : ControllerBase
    {
        protected readonly UserBaseViewModel userModel;

        public BaseController(ITokenService tokenService)
        {
            userModel = tokenService.GetUserInfoFromToken().Result.Data;
        }
    }
}
