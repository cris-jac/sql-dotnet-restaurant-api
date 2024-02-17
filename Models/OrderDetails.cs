using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantAPI.Models;

public class OrderDetails
{
    [Key]
    public int OrderDetailId { get; set; }
    public int OrderHeaderId { get; set; }
    public int MenuItemId { get; set; }
    [ForeignKey("MenuItemId")]
    public MenuItem MenuItem { get; set; }
    public int Quantity { get; set; }
    public string ItemName { get; set; }
    public double Price { get; set; }
    public string Image { get; set; }
}