using System.Net;
using RestaurantAPI.Data;
using RestaurantAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace RestaurantAPI.Controllers;

[ApiController]
[Route("api/shoppingCart")]
public class ShoppingCartController : ControllerBase
{
    private readonly ApplicationDbContext _db;
    private ApiResponse _response;
    public ShoppingCartController(ApplicationDbContext db)
    {
        _db = db;
        _response = new ApiResponse();
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse>> UpdateItemInCart(string userId, int menuItemId, int updateQuantityBy)
    {
        // Pick up shopping cart
        ShoppingCart shoppingCart = _db.ShoppingCarts.Include(x => x.CartItems).FirstOrDefault(x => x.UserId == userId);

        // Pick up the item
        MenuItem menuItem = _db.MenuItems.FirstOrDefault(x => x.Id == menuItemId);

        // If there's no item
        if (menuItem == null)
        {
            _response.StatusCode = HttpStatusCode.BadRequest;
            _response.IsSuccess = false;
            return BadRequest(_response);
        }

        //
        if (shoppingCart == null && updateQuantityBy > 0)
        {
            // Create a shopping cart
            ShoppingCart newCart = new()
            {
                UserId = userId
            };

            _db.ShoppingCarts.Add(newCart);
            _db.SaveChanges();

            // Fill the cart created
            CartItem newCartItem = new()
            {
                MenuItemId = menuItemId,
                Quantity = updateQuantityBy,
                ShoppingCartId = newCart.Id,
                MenuItem = null
            };

            _db.CartItems.Add(newCartItem);
            _db.SaveChanges();
        }
        else
        {
            // Shopping cart already exists
            CartItem cartItemInCart = shoppingCart.CartItems.FirstOrDefault(x => x.MenuItemId == menuItemId);
            
            // Check if the item is in the cart
            if (cartItemInCart == null)
            {
                // Item does not exist
                CartItem newCartItem = new()
                {
                    MenuItemId = menuItemId,
                    Quantity = updateQuantityBy,
                    ShoppingCartId = shoppingCart.Id,
                    MenuItem = null
                };
                _db.CartItems.Add(newCartItem);
                _db.SaveChanges();
            }
            else
            {
                // Item exists
                int newQuantity = cartItemInCart.Quantity + updateQuantityBy;

                if (updateQuantityBy == 0 || newQuantity <= 0)
                {
                    // remove cart item frorm cart
                    _db.CartItems.Remove(cartItemInCart);
                    // remove cart
                    if (shoppingCart.CartItems.Count() == 1)
                    {
                        _db.ShoppingCarts.Remove(shoppingCart);
                    }
                    _db.SaveChanges();
                }
                else
                {
                    // just remove cart item
                    cartItemInCart.Quantity = newQuantity;
                    _db.SaveChanges();
                }
            }
        }

        return _response;
    }

    
    [HttpGet]
    public async Task<ActionResult<ApiResponse>> GetShoppingCart(string userId)
    {
        try
        {
            ShoppingCart shoppingCart;

            if(string.IsNullOrEmpty(userId))
            {
                shoppingCart = new();
            }

            shoppingCart = _db.ShoppingCarts.Include(x => x.CartItems).ThenInclude(x => x.MenuItem).FirstOrDefault(x => x.UserId == userId);

            if (shoppingCart.CartItems != null && shoppingCart.CartItems.Count > 0)
            {
                shoppingCart.CartTotal = shoppingCart.CartItems.Sum(x => x.Quantity * x.MenuItem.PriceInUSD);
            }

            _response.Result = shoppingCart;
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);

        }
        catch (System.Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { ex.ToString() };
            _response.StatusCode = HttpStatusCode.BadRequest;
        }
        return _response;
    }
}