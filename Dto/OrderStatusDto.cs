namespace PublishingHouse.WebApi.Dto;

public class OrderStatusDto
{
    public int OrderStatusId { get; set; }
    public string? Name { get; set; }
    public DateTime? CreateDateTime { get; set; }
    public DateTime? UpdateDateTime { get; set; }
}

public class CreateOrderStatusDto
{
    public string? Name { get; set; }
    public DateTime? CreateDateTime { get; set; }
    public DateTime? UpdateDateTime { get; set; }
}

public class UpdateOrderStatusDto
{
    public string? Name { get; set; }
    public DateTime? CreateDateTime { get; set; }
    public DateTime? UpdateDateTime { get; set; }
}