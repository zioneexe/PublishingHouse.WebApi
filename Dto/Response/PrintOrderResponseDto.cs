namespace PublishingHouse.WebApi.Dto.Response;

public class PrintOrderResponseDto
{
    public int OrderId { get; set; }
    public int Number { get; set; }
    public string PrintType { get; set; } = null!;
    public string PaperType { get; set; } = null!;
    public string CoverType { get; set; } = null!;
    public string FasteningType { get; set; } = null!;
    public bool IsLaminated { get; set; }
    public double Price { get; set; }
    public DateOnly? RegistrationDate { get; set; }
    public DateOnly? CompletionDate { get; set; }
    public CustomerResponseDto? Customer { get; set; } 
    public EmployeeResponseDto? Employee { get; set; }
    public OrderStatusResponseDto? OrderStatus { get; set; }
}