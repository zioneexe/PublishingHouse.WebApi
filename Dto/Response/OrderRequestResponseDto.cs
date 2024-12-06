namespace PublishingHouse.WebApi.Dto.Response;
public class OrderRequestResponseDto
{
    public int OrderRequestId { get; set; }
    public string? BookName { get; set; }
    public string? AuthorName { get; set; }
    public string? Genre { get; set; }
    public int PublicationYear { get; set; }
    public int Quantity { get; set; }
    public string? PrintType { get; set; }
    public string? PaperType { get; set; }
    public string? CoverType { get; set; }
    public string? FasteningType { get; set; }
    public bool? IsLaminated { get; set; }
    public string? CoverImagePath { get; set; }
    public DateTime? CompletionDate { get; set; }
    public CustomerResponseDto? Customer { get; set; }
}