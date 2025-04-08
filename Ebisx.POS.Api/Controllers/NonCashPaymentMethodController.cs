using Ebisx.POS.Api.DTOs.NonCashPaymentMethod;
using Ebisx.POS.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ebisx.POS.Api.Controllers;

// Similarly, you would create controllers for NonCashPaymentMethodController, CustomerController,
// DiscountController, and DiscountTypeController.

// Below is an example of the `NonCashPaymentMethodController`.

[Route("api/[controller]")]
[ApiController]
public class NonCashPaymentMethodController : ControllerBase
{
    private readonly INonCashPaymentMethodService _nonCashPaymentMethodService;

    public NonCashPaymentMethodController(INonCashPaymentMethodService nonCashPaymentMethodService)
    {
        _nonCashPaymentMethodService = nonCashPaymentMethodService;
    }

    [HttpGet]
    [ProducesResponseType(type: typeof(IEnumerable<NonCashPaymentMethodResponseDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllNonCashPaymentMethods()
    {
        var nonCashPaymentMethods = await _nonCashPaymentMethodService.GetAllNonCashPaymentMethodsAsync();
        return Ok(nonCashPaymentMethods);
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(type: typeof(NonCashPaymentMethodResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetNonCashPaymentMethodById(int id)
    {
        var nonCashPaymentMethod = await _nonCashPaymentMethodService.GetNonCashPaymentMethodByIdAsync(id);
        if (nonCashPaymentMethod == null)
        {
            return NotFound();
        }
        return Ok(nonCashPaymentMethod);
    }

    [HttpPost]
    [ProducesResponseType(type: typeof(NonCashPaymentMethodResponseDto), StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateNonCashPaymentMethod(NonCashPaymentMethodRequestDto nonCashPaymentMethod)
    {
        var createdNonCashPaymentMethod = await _nonCashPaymentMethodService.CreateNonCashPaymentMethodAsync(nonCashPaymentMethod);
        return CreatedAtAction(nameof(GetNonCashPaymentMethodById), new { id = createdNonCashPaymentMethod.Id }, createdNonCashPaymentMethod);
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateNonCashPaymentMethod(int id, NonCashPaymentMethodRequestDto nonCashPaymentMethod)
    {
        var updated = await _nonCashPaymentMethodService.UpdateNonCashPaymentMethodAsync(id, nonCashPaymentMethod);
        if (!updated)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteNonCashPaymentMethod(int id)
    {
        var deleted = await _nonCashPaymentMethodService.DeleteNonCashPaymentMethodAsync(id);
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }
}
