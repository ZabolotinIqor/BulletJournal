using System.ComponentModel.DataAnnotations;

namespace BulletJournal.Core.DTO
{
    public class RegisterDTO
    {
        [Required]
        public string Email { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Invalid password length", MinimumLength = 6)]
        public string Password { get; set; }
    }
}
