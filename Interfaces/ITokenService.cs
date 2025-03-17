using ImplementJwtAuth.Models;

namespace ImplementJwtAuth.Interfaces
{
    public interface ITokenService
    {
        string GenerateAccessToken(User user);
        string GenerateRefreshToken();
    }
}
