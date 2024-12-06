using System.ComponentModel.DataAnnotations;

namespace PublishingHouse.WebApi.Dto.AuthDto
{
    public class RegisterCustomerRequestDto
    {
        [Required]
        public string UserName { get; set; } = default!;

        [Required]
        public string Password { get; set; } = default!;
        
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
    }
}