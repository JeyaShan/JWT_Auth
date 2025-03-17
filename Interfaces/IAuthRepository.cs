using ImplementJwtAuth.DTOs;
using ImplementJwtAuth.Models;

namespace ImplementJwtAuth.Interfaces
{
    public interface IAuthRepository
    {
        Task<bool> RegisterAsync(RegisterDto registerDto);
        Task<(string accessToken, string refreshToken)> LoginAsync(LoginDto loginDto);
        Task<User> GetUserByEmailAsync(string email);
        Task<(string accessToken, string refreshToken)> RefreshTokenAsync(string refreshToken);
    }
}
