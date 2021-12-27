using System.ComponentModel.DataAnnotations;

namespace AccessHomes.Domain.Auth
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
