using ImplementJwtAuth.DTOs;
using ImplementJwtAuth.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ImplementJwtAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepo;

        public AuthController(IAuthRepository authRepo)
        {
            _authRepo = authRepo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var success = await _authRepo.RegisterAsync(dto);
            if (!success) return BadRequest("Email already exists.");
            return Ok("Registered successfully.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var (accessToken, refreshToken) = await _authRepo.LoginAsync(dto);
            if (accessToken == null) return Unauthorized("Invalid credentials.");

            return Ok(new { AccessToken = accessToken, RefreshToken = refreshToken });
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] string refreshToken)
        {
            var (newAccessToken,newRefreshToken) = await _authRepo.RefreshTokenAsync(refreshToken);
            if (newAccessToken == null) return Unauthorized("Invalid refresh token.");
            return Ok(new { AccessToken = newAccessToken,RefreshToken = newRefreshToken });
        }
    }
}
