using JobApplicationEvaluation.Business.Abstract;
using JobApplicationEvaluation.Business.Constants;
using JobApplicationEvaluation.Core.Result;
using JobApplicationEvaluation.DataAccess.Abstract;
using JobApplicationEvaluation.Entity.Concrete;
using JobApplicationEvaluation.ViewModels.ResponseViewModel.Auth;
using Microsoft.AspNetCore.Identity;
using System.Net;
using System.Security.Claims;

namespace JobApplicationEvaluation.Business.Concrete
{
    public class AuthenticationManager : IAuthenticationService
    {
        private readonly IUserDal _userDal;
        private readonly ITokenService _tokenService;
        private readonly PasswordHasher<User> _passwordHasher;

        public AuthenticationManager(IUserDal userDal, ITokenService tokenService, PasswordHasher<User> passwordHasher)
        {
            _userDal = userDal;
            _tokenService = tokenService;
            _passwordHasher = passwordHasher;
        }

        public async Task<IResult> Login(string email, string password)
        {
            var user = await _userDal.SelectPropsAsync(u => u.Email == email, u => new User
            {
                Guid = u.Guid,
                FullName = u.FullName,
                PasswordHash = u.PasswordHash,
                IsActive = u.IsActive
            });

            if (user == null || !user.IsActive)
            {
                return new ErrorResult(UserMessages.UserNotFoundError, (int)HttpStatusCode.Unauthorized);
            }

            var verificationResult = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);
            if (verificationResult == PasswordVerificationResult.Failed)
            {
                return new ErrorResult(UserMessages.LoginFailed, (int)HttpStatusCode.Unauthorized);
            }

            return GenerateTokenForUser(user);
        }

        private IResult GenerateTokenForUser(User user)
        {
            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Guid.ToString()),
                    new Claim(ClaimTypes.Name, user.FullName),
                };

            var token = _tokenService.GenerateToken(claims);

            var response = new AuthResponseViewModel
            {
                Token = token,
            };

            return new SuccessDataResult<AuthResponseViewModel>(response, UserMessages.LoginSuccessful);
        }
    }
}
