using JobApplicationEvaluation.Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JobApplicationEvaluation.Business.Concrete
{
    public class TokenManager : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TokenManager(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
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
