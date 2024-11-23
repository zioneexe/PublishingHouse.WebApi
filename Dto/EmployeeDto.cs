namespace PublishingHouse.WebApi.Dto;

public class EmployeeDto
{
    public int EmployeeId { get; set; }
    public int UserId { get; set; }
    public int PositionId { get; set; }
    public int ProductionId { get; set; }
    public DateTime? CreateDateTime { get; set; }
    public DateTime? UpdateDateTime { get; set; }
}

public class CreateEmployeeDto
{
    public int UserId { get; set; }
    public int PositionId { get; set; }
    public int ProductionId { get; set; }
    public DateTime? CreateDateTime { get; set; }
    public DateTime? UpdateDateTime { get; set; }
}

public class UpdateEmployeeDto
{
    public int UserId { get; set; }
    public int PositionId { get; set; }
    public int ProductionId { get; set; }
    public DateTime? CreateDateTime { get; set; }
    public DateTime? UpdateDateTime { get; set; }
}