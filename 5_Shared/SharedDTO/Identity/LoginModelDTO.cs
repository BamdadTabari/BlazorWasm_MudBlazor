using System.ComponentModel.DataAnnotations;

namespace illegible.Shared.SharedDTO.Identity
{
    public class LoginModelDTO
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
