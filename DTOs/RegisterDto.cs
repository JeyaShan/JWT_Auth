using ImplementJwtAuth.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ImplementJwtAuth.DTOs
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Please Enter valid Email Format")]
        public string Email { get; set; } = string.Empty;
        [StrongPassword]
        public string Password { get; set; } = string.Empty;
        [Required(ErrorMessage = "Role is required")]
        public string Role { get; set; } = string.Empty;
    }
}
