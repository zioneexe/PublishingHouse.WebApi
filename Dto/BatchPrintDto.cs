namespace PublishingHouse.WebApi.Dto;

public class BatchPrintDto
{
    public int BatchPrintId { get; set; }
    public string Number { get; set; } = null!;
    public int BookQuantity { get; set; }
    public int OrderId { get; set; }
    public DateOnly? PrintDate { get; set; }
    public int QualityMarkId { get; set; }
    public DateTime? CreateDateTime { get; set; }
    public DateTime? UpdateDateTime { get; set; }
}

public class CreateBatchPrintDto
{
    public string Number { get; set; } = null!;
    public int BookQuantity { get; set; }
    public int OrderId { get; set; }
    public DateOnly? PrintDate { get; set; }
    public int QualityMarkId { get; set; }
    public DateTime? CreateDateTime { get; set; }
    public DateTime? UpdateDateTime { get; set; }
}

public class UpdateBatchPrintDto
{
    public string Number { get; set; } = null!;
    public int BookQuantity { get; set; }
    public int OrderId { get; set; }
    public DateOnly? PrintDate { get; set; }
    public int QualityMarkId { get; set; }
    public DateTime? CreateDateTime { get; set; }
    public DateTime? UpdateDateTime { get; set; }
}