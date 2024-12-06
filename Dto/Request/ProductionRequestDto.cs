namespace PublishingHouse.WebApi.Dto.Request;
public class ProductionRequestDto
{
    public int ProductionTypeId { get; set; }
    public int CityId { get; set; }
    public string? Address { get; set; }
}