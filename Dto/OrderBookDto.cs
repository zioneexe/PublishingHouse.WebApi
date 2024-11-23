namespace PublishingHouse.WebApi.Dto;

public class OrderBookDto
{
    public int OrderBookId { get; set; }
    public int OrderId { get; set; }
    public int BookId { get; set; }
    public int BookQuantity { get; set; }
    public DateTime? CreateDateTime { get; set; }
    public DateTime? UpdateDateTime { get; set; }
}

public class CreateOrderBookDto
{
    public int OrderId { get; set; }
    public int BookId { get; set; }
    public int BookQuantity { get; set; }
    public DateTime? CreateDateTime { get; set; }
    public DateTime? UpdateDateTime { get; set; }
}

public class UpdateOrderBookDto
{
    public int OrderId { get; set; }
public int BookId { get; set; }
public int BookQuantity { get; set; }
public DateTime? CreateDateTime { get; set; }
public DateTime? UpdateDateTime { get; set; }
}