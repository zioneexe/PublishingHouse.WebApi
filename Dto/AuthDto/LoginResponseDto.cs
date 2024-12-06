namespace PublishingHouse.WebApi.Dto.AuthDto
{
    public class LoginResponseDto
    {
        public string? UserName { get; set; } = default!;
        public string Role { get; set; } = default!;
        public string Token { get; set; } = default!;
        public int? Id { get; set; } 
    }
}
