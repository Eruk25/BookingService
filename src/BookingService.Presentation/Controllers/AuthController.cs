using BookingService.Application.DTOs.User;
using BookingService.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookingService.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;

    public AuthController(IUserService userService)
    {
        _userService = userService;
    }
    
    [HttpPost("register")]
    public async Task<ActionResult<bool>> RegisterAsync(RegisterUserDto user)
    {
        var success = await _userService.RegisterAsync(user);
        return Ok(success);
    }
    
    [HttpPost("login")]
    public async Task<ActionResult<string>> LoginAsync(LoginUserDto userDto)
    {
        var token = await _userService.LoginAsync(userDto);
        return Ok(token);
    }
}