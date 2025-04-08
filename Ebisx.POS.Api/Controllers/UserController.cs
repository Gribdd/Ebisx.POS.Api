using Ebisx.POS.Api.DTOs.SalesInvoice;
using Ebisx.POS.Api.DTOs.User;
using Ebisx.POS.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ebisx.POS.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    [ProducesResponseType(type: typeof(IEnumerable<UserResponseDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var users = await _userService.GetAllUsersAsync();
        return Ok(users);
    }

    [HttpGet("{privateId:int}")]
    [ProducesResponseType(type: typeof(UserResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int privateId)
    {
        var user = await _userService.GetUserByIdAsync(privateId);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }

    [HttpPost]
    [ProducesResponseType(type: typeof(UserResponseDto), StatusCodes.Status201Created)]
    public async Task<IActionResult> Create([FromBody] UserRequestDto user)
    {
        var createdUser = await _userService.CreateUserAsync(user);
        return CreatedAtAction(nameof(GetById), new { privateId = createdUser.PrivateId }, createdUser);
    }

    [HttpPut("{privateId:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(int privateId, [FromBody] UserRequestDto user)
    {
        var updated = await _userService.UpdateUserAsync(privateId, user);
        if (!updated)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpDelete("{privateId:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int privateId)
    {
        var deleted = await _userService.DeleteUserAsync(privateId);
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }
}
