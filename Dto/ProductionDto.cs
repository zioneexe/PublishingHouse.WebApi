namespace PublishingHouse.WebApi.Dto;

public class ProductionDto
{
    public int ProductionId { get; set; }
    public int ProductionTypeId { get; set; }
    public int CityId { get; set; }
    public string? Address { get; set; }
    public DateTime? CreateDateTime { get; set; }
    public DateTime? UpdateDateTime { get; set; }
}

public class CreateProductionDto
{
    public int ProductionTypeId { get; set; }
    public int CityId { get; set; }
    public string? Address { get; set; }
    public DateTime? CreateDateTime { get; set; }
    public DateTime? UpdateDateTime { get; set; }
}

public class UpdateProductionDto
{
    public int ProductionTypeId { get; set; }
    public int CityId { get; set; }
    public string? Address { get; set; }
    public DateTime? CreateDateTime { get; set; }
    public DateTime? UpdateDateTime { get; set; }
}