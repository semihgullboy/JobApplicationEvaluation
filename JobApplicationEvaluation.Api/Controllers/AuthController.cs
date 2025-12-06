using JobApplicationEvaluation.Business.Abstract;
using JobApplicationEvaluation.Core.Result;
using JobApplicationEvaluation.ViewModels.RequestViewModel.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobApplicationEvaluation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IUserService _userService;

        public AuthController(IAuthenticationService authenticationService, IUserService userService)
        {
            _authenticationService = authenticationService;
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(string email, string password)
        {
            var result = await _authenticationService.Login(email, password);

            if (result is ErrorResult errorResult)
            {
                return StatusCode(errorResult.StatusCode, errorResult);
            }

            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CreateUserRequestViewModel model)
        {
            var result = await _userService.CreateUserAsync(model);
            if (result is ErrorResult errorResult)
            {
                return StatusCode(errorResult.StatusCode, errorResult);
            }

            return Ok(result);
        }
    }
}
