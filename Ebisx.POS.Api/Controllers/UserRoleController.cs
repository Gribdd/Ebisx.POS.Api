using Ebisx.POS.Api.DTOs.UserRole;
using Ebisx.POS.Api.Entities;
using Ebisx.POS.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ebisx.POS.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserRoleController : ControllerBase
{
    private readonly IUserRoleService _userRoleService;

    public UserRoleController(IUserRoleService userRoleService)
    {
        _userRoleService = userRoleService;
    }

    [HttpGet]
    [ProducesResponseType(type: typeof(IEnumerable<UserRoleResponseDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var roles = await _userRoleService.GetAllRolesAsync();
        return Ok(roles);
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(type: typeof(UserRoleResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int id)
    {
        var role = await _userRoleService.GetRoleByIdAsync(id);
        if (role == null)
        {
            return NotFound();
        }
        return Ok(role);
    }

    [HttpPost]
    [ProducesResponseType(type: typeof(UserRoleResponseDto), StatusCodes.Status201Created)]
    public async Task<IActionResult> Create([FromBody] UserRoleRequestDto role)
    {
        var createdRole = await _userRoleService.CreateRoleAsync(role);
        return CreatedAtAction(nameof(GetById), new { id = createdRole.Id }, createdRole);
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(int id, [FromBody] UserRoleRequestDto role)
    {
        var updated = await _userRoleService.UpdateRoleAsync(id, role);
        if (!updated)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _userRoleService.DeleteRoleAsync(id);
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }
}
