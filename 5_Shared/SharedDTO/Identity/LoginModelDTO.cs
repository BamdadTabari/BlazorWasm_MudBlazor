using System.ComponentModel.DataAnnotations;

namespace illegible.Shared.SharedDto.Identity
{
    public class LoginModelDto
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
