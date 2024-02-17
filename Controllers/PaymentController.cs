using System.Net;
using RestaurantAPI.Data;
using RestaurantAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stripe;

namespace RestaurantAPI.Controllers;

[ApiController]
[Route("api/payment")]
public class PaymentController : ControllerBase
{
    private readonly ApplicationDbContext _db;
    private readonly IConfiguration _configuration;
    private ApiResponse _response;
    public PaymentController(ApplicationDbContext db, IConfiguration configuration)
    {
        _db = db;
        _configuration = configuration;
        _response = new ApiResponse();
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse>> MakePayment(string userId)
    {
        ShoppingCart shoppingCart = await _db.ShoppingCarts.Include(x => x.CartItems).ThenInclude(x => x.MenuItem).FirstOrDefaultAsync(x => x.UserId == userId);

        if (shoppingCart == null)
        {
            _response.StatusCode = HttpStatusCode.NotFound;
            _response.IsSuccess = false;
            _response.ErrorMessages.Add("The cart's Id is not registered");
            return NotFound(_response);
        }

        if (shoppingCart.CartItems == null || shoppingCart.CartItems.Count() == 0)
        {
            _response.StatusCode = HttpStatusCode.BadRequest;
            _response.IsSuccess = false;
            _response.ErrorMessages.Add($"This cart has {shoppingCart.CartItems.Count()} items");
            return BadRequest(_response);
        }

        // Stripe config
        StripeConfiguration.ApiKey = _configuration["StripeSettings:SecretKey"];
        shoppingCart.CartTotal = shoppingCart.CartItems.Sum(x => x.Quantity * x.MenuItem.PriceInUSD);

        var options = new PaymentIntentCreateOptions
        {
            Amount = (int)(shoppingCart.CartTotal * 100),
            Currency = "usd",
            PaymentMethodTypes = new List<string>
            {
                "card"
            }
        };

        var service = new PaymentIntentService();
        var response = service.Create(options);

        shoppingCart.StripePaymentId = response.Id;      // Stripe Payment Intent 
        shoppingCart.ClientSecret = response.ClientSecret;      // Later

        //

        _response.Result = shoppingCart;
        _response.StatusCode = HttpStatusCode.OK;
        return Ok(_response);
    }
}