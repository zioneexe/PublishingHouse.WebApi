namespace PublishingHouse.WebApi.Dto.Response;

public class CustomerResponseDto
{
    public int CustomerId { get; set; }
    public int CustomerTypeId { get; set; }
    public string Name { get; set; } = null!;
    public DateOnly? AddressDate { get; set; }
    public string? Email { get; set; }
}