using RestaurantAPI.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantAPI.Controllers;

[ApiController]
[Route("test-auth")]
public class TestAuthController : ControllerBase
{
    [HttpGet("authentication")]
    [Authorize]
    public async Task<ActionResult<string>> TestAuthentication()
    {
        return "You are authenticated";
    }

    [HttpGet("authorization")]
    [Authorize(Roles = SD.Role_Admin)]
    public async Task<ActionResult<string>> TestAuthorization()
    {
        return "You are authorized as an Admin";
    }
}