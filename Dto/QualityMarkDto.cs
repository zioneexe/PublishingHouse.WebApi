namespace PublishingHouse.WebApi.Dto;

public class QualityMarkDto
{
    public int QualityMarkId { get; set; }
    public string? Name { get; set; }
    public DateTime? CreateDateTime { get; set; }
    public DateTime? UpdateDateTime { get; set; }
}

public class CreateQualityMarkDto
{
    public string? Name { get; set; }
    public DateTime? CreateDateTime { get; set; }
    public DateTime? UpdateDateTime { get; set; }
}

public class UpdateQualityMarkDto
{
    public string? Name { get; set; }
    public DateTime? CreateDateTime { get; set; }
    public DateTime? UpdateDateTime { get; set; }
}