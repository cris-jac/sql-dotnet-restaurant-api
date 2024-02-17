namespace RestaurantAPI.Models.DTO;

public class OrderHeaderCreateDto
{
    public string ContactName { get; set; }
    public string ContactPhoneNumber { get; set; }
    public string ContactEmail { get; set; }
    public string ApplicationUserId { get; set; }
    public double OrderTotal { get; set; }
    public string StripePaymentIntentId { get; set; }
    public string Status { get; set; }
    public int TotalItems { get; set; }
    public IEnumerable<OrderDetailsCreateDto> OrderDetailsDto { get; set; }
}