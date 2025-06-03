using System.ComponentModel.DataAnnotations;

namespace FiapCloudGamesAPI.DTOs.Auth
{
    public class RegisterDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MinLength(8)]
        [RegularExpression(@"^(?=.*[a-zA-Z])(?=.*\d)(?=.*[\W_]).+$",
            ErrorMessage = "A senha deve conter letras, números e um caractere especial.")]
        public string Password { get; set; } = string.Empty;
    }
}
