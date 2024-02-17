using Microsoft.AspNetCore.Identity;

namespace RestaurantAPI.Models;

public class ApplicationUser : IdentityUser
{
    public string Name { get; set; }
}