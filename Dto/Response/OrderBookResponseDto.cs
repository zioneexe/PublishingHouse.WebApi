namespace PublishingHouse.WebApi.Dto.Response;

public class OrderBookResponseDto
{
    public int OrderBookId { get; set; }
    public int OrderId { get; set; }
    public int BookId { get; set; }
    public int BookQuantity { get; set; }
    public BookResponseDto? Book { get; set; }
}