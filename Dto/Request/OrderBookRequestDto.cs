namespace PublishingHouse.WebApi.Dto.Request;

public class OrderBookRequestDto
{
    public int OrderId { get; set; }
    public int BookId { get; set; }
    public int BookQuantity { get; set; }
}