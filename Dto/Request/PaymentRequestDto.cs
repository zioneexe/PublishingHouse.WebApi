namespace PublishingHouse.WebApi.Dto.Request;
public class PaymentRequestDto
{
    public double Amount { get; set; }
    public string CardNumber { get; set; } = string.Empty;
    public string ExpiryDate { get; set; } = string.Empty;
    public string Cvv { get; set; } = string.Empty;
}