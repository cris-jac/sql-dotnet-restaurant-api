using System.Net;
using RestaurantAPI.Data;
using RestaurantAPI.Models;
using RestaurantAPI.Models.DTO;
using RestaurantAPI.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Helpers;

namespace RestaurantAPI.Controllers;

[ApiController]
[Route("api/orders")]
public class OrderController : ControllerBase
{
    private readonly ApplicationDbContext _db;
    private ApiResponse _response;
    public OrderController(ApplicationDbContext db)
    {
        _db = db;
        _response = new ApiResponse();
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse>> GetOrders(string? userId)
    {
        try
        {
            var orderHeaders = _db.OrderHeaders.Include(x => x.OrderDetails).ThenInclude(x => x.MenuItem).OrderByDescending(x => x.OrderHeaderId);

            if (!string.IsNullOrEmpty(userId))
            {
                _response.Result = orderHeaders.Where(x => x.ApplicationUserId == userId);
            }
            else
            {
                _response.Result = orderHeaders;
            }
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }
        catch (System.Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { ex.ToString() };
        }
        return _response;
    }


    [HttpGet("{id:int}")]
    public async Task<ActionResult<ApiResponse>> GetOrder(int id)
    {
        try
        {
            if (id == 0)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                return BadRequest(_response);
            }

            var orderHeaders = _db.OrderHeaders.Include(x => x.OrderDetails).ThenInclude(x => x.MenuItem).Where(x => x.OrderHeaderId == id);

            if (orderHeaders == null)
            {
                _response.StatusCode = HttpStatusCode.NotFound;
                return NotFound(_response);
            }

            _response.Result = orderHeaders;
            _response.StatusCode = HttpStatusCode.OK;
            return NotFound(_response);
        }
        catch (System.Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { ex.ToString() };
        }

        return _response;
    }


    [HttpPost]
    public async Task<ActionResult<ApiResponse>> CreateOrder([FromBody] OrderHeaderCreateDto orderHeaderDto)
    {
        try
        {
            OrderHeader newOrder = new()
            {
                ContactName = orderHeaderDto.ContactName,
                ContactPhoneNumber = orderHeaderDto.ContactPhoneNumber,
                ContactEmail = orderHeaderDto.ContactEmail,
                ApplicationUserId = orderHeaderDto.ApplicationUserId,
                OrderTotal = orderHeaderDto.OrderTotal,
                OrderDate = DateTime.UtcNow,
                StripePaymentIntentId = orderHeaderDto.StripePaymentIntentId,
                TotalItems = orderHeaderDto.TotalItems,
                Status = string.IsNullOrEmpty(orderHeaderDto.Status) ? SD.status_pending : orderHeaderDto.Status
            };

            if (ModelState.IsValid)
            {
                _db.OrderHeaders.Add(newOrder);
                _db.SaveChanges();
                foreach(var orderDetailDto in orderHeaderDto.OrderDetailsDto)
                {
                    OrderDetails orderDetails = new()
                    {
                        OrderHeaderId = newOrder.OrderHeaderId,
                        ItemName = orderDetailDto.ItemName,
                        MenuItemId = orderDetailDto.MenuItemId,
                        Price = orderDetailDto.Price,
                        Quantity = orderDetailDto.Quantity,
                        Image = orderDetailDto.Image
                    };

                    _db.OrderDetails.Add(orderDetails);
                }

                _db.SaveChanges();

                _response.Result = newOrder;
                newOrder.OrderDetails = null;
                _response.StatusCode = HttpStatusCode.Created;

                return Ok(_response);
            }
        }
        catch (System.Exception ex)
        {
            _response.IsSuccess = false;
            // _response.ErrorMessages = new List<string>() { ex.ToString() };
            _response.ErrorMessages = ErrorHelper.ExtractErrorMessages(ex);
        }

        return _response;
    }


    [HttpPut("{id:int}")]
    public async Task<ActionResult<ApiResponse>> UpdateOrderHeader(int id, [FromBody] OrderHeaderUpdateDto orderUpdateDto)
    {
        try
        {
            if (orderUpdateDto == null || id != orderUpdateDto.OrderHeaderId)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                return BadRequest(_response);
            }

            OrderHeader orderFromDb = _db.OrderHeaders.FirstOrDefault(x => x.OrderHeaderId == id);

            if (orderFromDb == null)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                return BadRequest(_response);
            }

            if (!string.IsNullOrEmpty(orderUpdateDto.ContactName))
            {
                orderFromDb.ContactName = orderUpdateDto.ContactName;
            }

            if (!string.IsNullOrEmpty(orderUpdateDto.ContactEmail))
            {
                orderFromDb.ContactEmail = orderUpdateDto.ContactEmail;
            }

            if (!string.IsNullOrEmpty(orderUpdateDto.ContactPhoneNumber))
            {
                orderFromDb.ContactPhoneNumber = orderUpdateDto.ContactPhoneNumber;
            }

            if (!string.IsNullOrEmpty(orderUpdateDto.Status))
            {
                orderFromDb.Status = orderUpdateDto.Status;
            }

            if (!string.IsNullOrEmpty(orderUpdateDto.StripePaymentIntentId))
            {
                orderFromDb.StripePaymentIntentId = orderUpdateDto.StripePaymentIntentId;
            }

            _db.SaveChanges();
            _response.StatusCode = HttpStatusCode.NoContent;
            _response.IsSuccess = true;
            return Ok(_response);
        }
        catch (System.Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { ex.ToString() };
        }

        return _response;
    }
}