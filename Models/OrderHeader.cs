using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantAPI.Models;

public class OrderHeader
{
    [Key]
    public int OrderHeaderId { get; set; }
    public string ContactName { get; set; }
    public string ContactPhoneNumber { get; set; }
    public string ContactEmail { get; set; }
    public string ApplicationUserId { get; set; }
    [ForeignKey("ApplicationUserId")]
    public ApplicationUser User { get; set; }
    public double OrderTotal { get; set; }
    public DateTime OrderDate { get; set; }
    public string StripePaymentIntentId { get; set; }
    public string Status { get; set; }
    public int TotalItems { get; set; }
    public IEnumerable<OrderDetails> OrderDetails { get; set; }
}