namespace PublishingHouse.WebApi.Dto.Response;

public class ProductionResponseDto
{
    public int ProductionId { get; set; }
    public int ProductionTypeId { get; set; }
    public int CityId { get; set; }
    public string? Address { get; set; }
}