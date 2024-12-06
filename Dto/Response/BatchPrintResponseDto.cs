namespace PublishingHouse.WebApi.Dto.Response;

public class BatchPrintResponseDto
{
    public int BatchPrintId { get; set; }
    public string Number { get; set; } = null!;
    public int BookQuantity { get; set; }
    public int OrderId { get; set; }
    public DateOnly? PrintDate { get; set; }
    public int QualityMarkId { get; set; }
}