using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ImplementJwtAuth.Attributes
{
    public class StrongPasswordAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            string password = value as string ?? string.Empty;

            if (string.IsNullOrEmpty(password)) return false;

            
            return password.Length >= 8 &&
                   Regex.IsMatch(password, "[A-Z]") &&           
                   Regex.IsMatch(password, @"\d") &&            
                   Regex.IsMatch(password, @"[\W_]");            
        }

        public override string FormatErrorMessage(string name)
        {
            return "Password must be at least 8 characters, include 1 uppercase letter, 1 number, and 1 special character.";
        }
    }
}
