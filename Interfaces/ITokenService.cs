using System.Security.Claims;
using RestaurantAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantAPI.Interfaces;

public interface ITokenService
{
    public string GenerateToken(ApplicationUser user, IList<string> roles);
    public ActionResult<ClaimsPrincipal> ValidateToken(string token);
    // public RefreshToken GenerateRefreshToken();
}