namespace PublishingHouse.WebApi.Dto;

public class CustomerDto
{
    public int CustomerId { get; set; }
    public int CustomerTypeId { get; set; }
    public string Name { get; set; } = null!;
    public DateOnly? AddressDate { get; set; }
    public string? Email { get; set; }
    public DateTime? CreateDateTime { get; set; }
    public DateTime? UpdateDateTime { get; set; }
}

public class CreateCustomerDto
{
    public int CustomerTypeId { get; set; }
    public string Name { get; set; } = null!;
    public DateOnly? AddressDate { get; set; }
    public string? Email { get; set; }
    public DateTime? CreateDateTime { get; set; }
    public DateTime? UpdateDateTime { get; set; }
}

public class UpdateCustomerDto
{
    public int CustomerTypeId { get; set; }
    public string Name { get; set; } = null!;
    public DateOnly? AddressDate { get; set; }
    public string? Email { get; set; }
    public DateTime? CreateDateTime { get; set; }
    public DateTime? UpdateDateTime { get; set; }
}