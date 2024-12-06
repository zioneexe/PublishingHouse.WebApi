namespace PublishingHouse.WebApi.Dto.Response;

public class EmployeeResponseDto
{
    public int EmployeeId { get; set; }
    public int PositionId { get; set; }
    public int ProductionId { get; set; }
    public string? Name { get; set; }
}