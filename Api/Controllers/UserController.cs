using Domain;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet()]
    // [ProducesResponseType(typeof(List<User>), 200)]
    public async Task<IActionResult> GetAllAsync()
    {
        try
        {
            return Ok(await _userService.GetAllAsync());
        }
        catch (Exception ex)
        {
            return NotFound("");
        }
        // return BadRequest("Oops!");
    }
}
