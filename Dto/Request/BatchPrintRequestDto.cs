namespace PublishingHouse.WebApi.Dto.Request;
public class BatchPrintRequestDto
{
    public string Number { get; set; } = null!;
    public int BookQuantity { get; set; }
    public int OrderId { get; set; }
    public DateOnly? PrintDate { get; set; }
    public int QualityMarkId { get; set; }
}