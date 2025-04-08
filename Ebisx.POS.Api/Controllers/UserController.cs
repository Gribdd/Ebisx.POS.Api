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
    public async Task<ActionResult<UserResponseDto>> GetAll()
    {
        var users = await _userService.GetAllUsersAsync();
        return Ok(users);
    }

    [HttpGet("{privateId:int}")]
    public async Task<ActionResult<UserResponseDto>> GetById(int privateId)
    {
        var user = await _userService.GetUserByIdAsync(privateId);
        if (user == null)
            return NotFound();

        return Ok(user);
    }

    [HttpPost]
    public async Task<ActionResult<UserResponseDto>> Create([FromBody] UserRequestDto user)
    {
        var createdUser = await _userService.CreateUserAsync(user);
        return CreatedAtAction(nameof(GetById), new { privateId = createdUser.PrivateId }, createdUser);
    }

    [HttpPut("{privateId:int}")]
    public async Task<IActionResult> Update(int privateId, [FromBody] UserRequestDto user)
    {
        var updated = await _userService.UpdateUserAsync(privateId, user);
        if (!updated)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{privateId:int}")]
    public async Task<IActionResult> Delete(int privateId)
    {
        var deleted = await _userService.DeleteUserAsync(privateId);
        if (!deleted)
            return NotFound();

        return NoContent();
    }
}
