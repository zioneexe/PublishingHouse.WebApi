namespace PublishingHouse.WebApi.Dto;

public class PrintOrderDto
{
    public int OrderId { get; set; }
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
    public DateTime? CreateDateTime { get; set; }
    public DateTime? UpdateDateTime { get; set; }
}

public class CreatePrintOrderDto
{
    public int OrderId { get; set; }
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
    public DateTime? CreateDateTime { get; set; }
    public DateTime? UpdateDateTime { get; set; }
}

public class UpdatePrintOrderDto
{
    public int OrderId { get; set; }
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
    public DateTime? CreateDateTime { get; set; }
    public DateTime? UpdateDateTime { get; set; }
}