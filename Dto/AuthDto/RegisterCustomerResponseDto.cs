namespace PublishingHouse.WebApi.Dto.AuthDto
{
    public class RegisterCustomerResponseDto
    {
        public string UserName { get; set; } = default!;
        public string Role { get; set; } = default!;
        public int CustomerId { get; set; }
    }
}
