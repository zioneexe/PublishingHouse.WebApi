namespace PublishingHouse.WebApi.Dto.Request;
public class PrintOrderRequestDto
{
    public int Number { get; set; }
    public string PrintType { get; set; } = null!;
    public string PaperType { get; set; } = null!;
    public string CoverType { get; set; } = null!;
    public string FasteningType { get; set; } = null!;
    public bool IsLaminated { get; set; }
    public double Price { get; set; }
    public int OrderStatusId { get; set; }
    public DateOnly? RegistrationDate { get; set; }
    public DateOnly? CompletionDate { get; set; }
    public int CustomerId { get; set; }
    public int EmployeeId { get; set; }
}