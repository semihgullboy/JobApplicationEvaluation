using JobApplicationEvaluation.Business.Abstract;
using JobApplicationEvaluation.Core.Result;
using JobApplicationEvaluation.ViewModels.BaseViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace JobApplicationEvaluation.Business.Concrete
{
    public class TokenManager : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TokenManager(IConfiguration configuration, IUserService userService, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _userService = userService;
            _httpContextAccessor = httpContextAccessor;
        }

        public string GenerateToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(_configuration["JWTAuth:SecretKey"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWTAuth:ValidIssuerURL"],
                audience: _configuration["JWTAuth:ValidAudienceURL"],
                expires: DateTime.Now.AddDays(int.Parse(_configuration["JWTAuth:Expire"])),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey,
                SecurityAlgorithms.HmacSha256)
                );

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }

        public async Task<IDataResult<UserBaseViewModel>> GetUserInfoFromToken()
        {
            var context = _httpContextAccessor.HttpContext;
            var authorizationHeader = context?.Request.Headers["Authorization"].FirstOrDefault();

            if (string.IsNullOrEmpty(authorizationHeader) || !authorizationHeader.StartsWith("Bearer "))
            {
                return new ErrorDataResult<UserBaseViewModel>(
                    "Kullanıcı bilgisi geçersiz veya hatalı.",
                    (int)HttpStatusCode.NotFound
                );
            }

            var token = authorizationHeader.Substring("Bearer ".Length).Trim();

            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token);

            var userGuid = jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userGuid))
            {
                return new ErrorDataResult<UserBaseViewModel>(
                    "Kullanıcı bilgisi bulunamadı.",
                    (int)HttpStatusCode.NotFound
                );
            }

            return await _userService.GetUserByGuidIdAsync(userGuid);
        }

        public bool IsTokenValid(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(_configuration["JWTAuth:SecretKey"]);

                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = _configuration["JWTAuth:ValidIssuerURL"],
                    ValidAudience = _configuration["JWTAuth:ValidAudienceURL"],
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };

                tokenHandler.ValidateToken(token, validationParameters, out var validatedToken);

                return validatedToken != null;
            }
            catch (SecurityTokenExpiredException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
