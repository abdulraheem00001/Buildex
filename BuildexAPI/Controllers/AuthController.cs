using BuildexAPI.Models;
using BuildexAPI.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;
    public AuthController(AuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("AddUser")]
    public IActionResult AddUser([FromBody] User user)
    {
        var result = _authService.AddUser(user);
        if (result.Success)
            return Ok(new { success = true, message = result.Message });
        else
            return BadRequest(new { success = false, message = result.Message });
    }

    [HttpPost("Login")]
    public IActionResult Login([FromBody] User user)
    {
        var result = _authService.Login(user);
        if (result.Success)
            return Ok(new { success = true, message = result.Message });
        else
            return BadRequest(new { success = false, message = result.Message });
    }
}
