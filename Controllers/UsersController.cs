using ImplementJwtAuth.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ImplementJwtAuth.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IAuthRepository _authRepo;

        public UsersController(IAuthRepository authRepo)
        {
            _authRepo = authRepo;
        }

        [HttpGet("profile")]
        public async Task<IActionResult> Profile()
        {
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            var user = await _authRepo.GetUserByEmailAsync(email?? string.Empty);
            return Ok(new { user.Email, user.Role });
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("adminRole")]
        public IActionResult AdminData()
        {
            return Ok("This is admin-only data.");
        }
    }
}
