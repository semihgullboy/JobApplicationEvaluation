using System.Security.Claims;

namespace JobApplicationEvaluation.Business.Abstract
{
    public interface ITokenService
    {
        string GenerateToken(List<Claim> authClaims);
        bool IsTokenValid(string token);
    }
}
