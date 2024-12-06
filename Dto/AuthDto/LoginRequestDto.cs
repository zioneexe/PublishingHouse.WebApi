namespace PublishingHouse.WebApi.Dto.AuthDto
{
    public class LoginRequestDto
    {
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}
