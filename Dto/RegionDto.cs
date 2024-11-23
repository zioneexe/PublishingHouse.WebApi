namespace PublishingHouse.WebApi.Dto;

public class RegionDto
{
    public int RegionId { get; set; }
    public string? Name { get; set; }
    public DateTime? CreateDateTime { get; set; }
    public DateTime? UpdateDateTime { get; set; }
}

public class CreateRegionDto
{
    public string? Name { get; set; }
    public DateTime? CreateDateTime { get; set; }
    public DateTime? UpdateDateTime { get; set; }
}

public class UpdateRegionDto
{
    public string? Name { get; set; }
    public DateTime? CreateDateTime { get; set; }
    public DateTime? UpdateDateTime { get; set; }
}