namespace RestaurantAPI.Models.DTO;

public class OrderHeaderUpdateDto
{
    public int OrderHeaderId { get; set; }
    public string ContactName { get; set; }
    public string ContactPhoneNumber { get; set; }
    public string ContactEmail { get; set; }
    public string StripePaymentIntentId { get; set; }
    public string Status { get; set; }
}