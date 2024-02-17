using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using RestaurantAPI.Data;
using RestaurantAPI.Interfaces;
using RestaurantAPI.Models;
using RestaurantAPI.Models.DTO;
using RestaurantAPI.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace RestaurantAPI.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly ApplicationDbContext _db;
    private readonly IConfiguration _configuration;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly ITokenService _tokenService;
    private string secretKey;
    private ApiResponse _response;
    public AuthController(
        ApplicationDbContext db,
        IConfiguration configuration,
        UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager,
        ITokenService tokenService
    )
    {
        _db = db;
        secretKey = configuration.GetValue<string>("AuthSettings:Secret");
        _response = new ApiResponse();
        _userManager = userManager;
        _roleManager = roleManager;
        _tokenService = tokenService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequestDto requestDto)
    {
        ApplicationUser userFromDb = _db.ApplicationUsers.FirstOrDefault(u => u.UserName.ToLower() == requestDto.UserName);

        if (userFromDb != null)
        {
            _response.StatusCode = HttpStatusCode.BadRequest;
            _response.IsSuccess = false;
            _response.ErrorMessages.Add("Username already exists");
            return BadRequest(_response);
        }

        ApplicationUser newUser = new ApplicationUser()
        {
            UserName = requestDto.UserName,
            Email = requestDto.Email,
            NormalizedUserName = requestDto.UserName.ToUpper(),
            Name = requestDto.Name
        };

        var result = await _userManager.CreateAsync(newUser, requestDto.Password);

        if (result.Succeeded)
        {
            if (!_roleManager.RoleExistsAsync(SD.Role_Admin).GetAwaiter().GetResult())
            {
                await _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin));
                await _roleManager.CreateAsync(new IdentityRole(SD.Role_Customer));
            }

            if (requestDto.Role.ToLower() == SD.Role_Admin)
            {
                await _userManager.AddToRoleAsync(newUser, SD.Role_Admin);
            }
            else
            {
                await _userManager.AddToRoleAsync(newUser, SD.Role_Customer);
            }

            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            return Ok(_response);
        }

        _response.StatusCode = HttpStatusCode.BadRequest;
        _response.IsSuccess = false;
        _response.ErrorMessages.Add("Error while registering");
        return BadRequest(_response);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto requestDto)
    {
        try
        {
            ApplicationUser userFromDb = _db.ApplicationUsers.FirstOrDefault(u => u.Email == requestDto.Email);

            bool isValid = await _userManager.CheckPasswordAsync(userFromDb, requestDto.Password);

            if (isValid == false)
            {
                _response.Result = new LoginResponseDto();
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Username or password is incorrect");
                return BadRequest(_response);
            }

            var roles = await _userManager.GetRolesAsync(userFromDb);

            // Generate
            // JwtSecurityTokenHandler tokenHandler = new();
            // byte[] key = Encoding.ASCII.GetBytes(secretKey);
            // SecurityTokenDescriptor tokenDescriptor = new()
            // {
            //     Subject = new ClaimsIdentity(new Claim[]
            //     {
            //         new Claim("fullName", userFromDb.Name),
            //         new Claim("id", userFromDb.Id.ToString()),
            //         new Claim(ClaimTypes.Email, userFromDb.Email),
            //         new Claim(ClaimTypes.Role, roles.FirstOrDefault())
            //     }),
            //     Expires = DateTime.UtcNow.AddMinutes(5),
            //     SigningCredentials = new SigningCredentials(
            //         new SymmetricSecurityKey(key),
            //         SecurityAlgorithms.HmacSha256Signature
            //     )
            // };
            // SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            // Generate Token
            string token = _tokenService.GenerateToken(userFromDb, roles);

            // Validate Token
            if (_tokenService.ValidateToken(token) == null)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Jwt Token not validated");
                return BadRequest(_response);
            }

            // Response
            LoginResponseDto loginResponse = new()
            {
                Email = userFromDb.Email,
                Token = token
            };

            if (loginResponse.Email == null || string.IsNullOrEmpty(loginResponse.Token))
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Username or password is incorrect");
                return BadRequest(_response);
            }

            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            _response.Result = loginResponse;
            return Ok(_response);
        }
        catch (System.Exception ex)
        {
            _response.IsSuccess = false;
            _response.StatusCode = HttpStatusCode.BadRequest;
            _response.ErrorMessages.Add(ex.ToString());
            return BadRequest(_response);
        }
    }
}