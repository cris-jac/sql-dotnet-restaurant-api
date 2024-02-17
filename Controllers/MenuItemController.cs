using System.Net;
using RestaurantAPI.Data;
using RestaurantAPI.Models;
using RestaurantAPI.Models.DTO;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace RestaurantAPI.Controllers;

[ApiController]
[Route("api/menuItems")]
public class MenuItemController : ControllerBase
{
    private readonly ApplicationDbContext _dbContext;
    private ApiResponse _response;
    public MenuItemController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        _response = new ApiResponse();
    }

    [HttpGet]
    public async Task<IActionResult> GetMenuItems()
    {
        _response.Result = await _dbContext.MenuItems.ToListAsync();
        _response.StatusCode = HttpStatusCode.OK;
        return Ok(_response);
    }

    [HttpGet("{id:int}", Name="GetMenuItem")]
    public async Task<IActionResult> GetMenuItem(int id)
    {
        if (id == 0)
        {
            _response.StatusCode = HttpStatusCode.BadRequest;
            _response.IsSuccess = false;
            return BadRequest(_response);
        }

        MenuItem menuItem = await _dbContext.MenuItems.FirstOrDefaultAsync(x => x.Id == id);

        if (menuItem == null)
        {
            _response.StatusCode = HttpStatusCode.NotFound;
            _response.IsSuccess = false;
            return NotFound(_response);
        }

        _response.Result = menuItem;
        _response.StatusCode = HttpStatusCode.OK;
        return Ok(_response);
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse>> CreateMenuItem(MenuItemCreateDto menuItemCreateDto)
    {
        try
        {
            // if (ModelState.IsValid)
            // {
            //     if (menuItemCreateDto.File == null)
            // }

            MenuItem menuItemToCreate = new()
            {
                Name = menuItemCreateDto.Name,
                PriceInUSD = menuItemCreateDto.Price,
                Category = menuItemCreateDto.Category,
                SpecialTag = menuItemCreateDto.SpecialTag,
                Description = menuItemCreateDto.Description
            };

            _dbContext.MenuItems.Add(menuItemToCreate);
            await _dbContext.SaveChangesAsync();

            _response.Result = menuItemToCreate;
            _response.StatusCode = HttpStatusCode.OK;

            return CreatedAtRoute("GetMenuItem", new { id = menuItemToCreate.Id }, _response);
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { ex.ToString() };
        }

        return _response;
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<ApiResponse>> CreateMenuItem(int id, MenuItemUpdateDto menuItemUpdateDto)
    {
        try
        {
            // if (ModelState.IsValid)
            // {
            //     if (menuItemCreateDto.File == null)
            // }

            if (menuItemUpdateDto == null || id != menuItemUpdateDto.Id)
            {
                return BadRequest();
            }

            MenuItem menuItemFromDb = await _dbContext.MenuItems.FirstOrDefaultAsync(x => x.Id == id);

            if (menuItemFromDb == null)
            {
                return BadRequest();
            }
          
            menuItemFromDb.Name = menuItemUpdateDto.Name;
            menuItemFromDb.PriceInUSD = menuItemUpdateDto.Price;
            menuItemFromDb.Category = menuItemUpdateDto.Category;
            menuItemFromDb.SpecialTag = menuItemUpdateDto.SpecialTag;
            menuItemFromDb.Description = menuItemUpdateDto.Description;
            

            _dbContext.MenuItems.Update(menuItemFromDb);
            await _dbContext.SaveChangesAsync();

            _response.StatusCode = HttpStatusCode.NoContent;

            return Ok(_response);
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { ex.ToString() };
        }

        return _response;
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<ApiResponse>> DeleteMenuItem(int id)
    {
        try
        {
            // if (ModelState.IsValid)
            // {
            //     if (menuItemCreateDto.File == null)
            // }

            if (id == 0)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                return BadRequest(_response);
            }

            MenuItem menuItemFromDb = await _dbContext.MenuItems.FirstOrDefaultAsync(x => x.Id == id);

            if (menuItemFromDb == null)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                return BadRequest(_response);
            }

            _dbContext.MenuItems.Remove(menuItemFromDb);
            _dbContext.SaveChanges();

            int milliseconds = 2000;
            Thread.Sleep(milliseconds);

            _response.StatusCode = HttpStatusCode.NoContent;

            return Ok(_response);
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { ex.ToString() };
        }

        return _response;
    }
}