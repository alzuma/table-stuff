using Microsoft.AspNetCore.Mvc;
using TableResponseDemo.Services;

namespace TableResponseDemo.Controllers;

[ApiController]
[Route("api/tables/users")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("{name}")]
    public IActionResult GetUser(string name, [FromQuery] bool rowsOnly = false)
    {
        var result = _userService.GetUser(name, rowsOnly);
        return Ok(result.Response);
    }

    [HttpGet("rows")]
    public IActionResult GetUsers([FromQuery] bool rowsOnly = false)
    {
        var result = _userService.GetUsers(rowsOnly);
        return Ok(result.Response);
    }
}