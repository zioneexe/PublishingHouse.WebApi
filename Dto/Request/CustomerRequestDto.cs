namespace PublishingHouse.WebApi.Dto.Request;
public class CustomerRequestDto
{
    public int CustomerTypeId { get; set; }
    public string Name { get; set; } = null!;
    public DateOnly? AddressDate { get; set; }
    public string? Email { get; set; }
}