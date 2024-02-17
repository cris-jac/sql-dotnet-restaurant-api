namespace RestaurantAPI.Models;

public class MenuItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string SpecialTag { get; set; }
    public string Category { get; set; }
    public double PriceInUSD { get; set; }
    public string Image { get; set; }
}