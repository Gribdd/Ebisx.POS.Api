using Ebisx.POS.Api.DTOs.Discount;
using Ebisx.POS.Api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ebisx.POS.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DiscountController : ControllerBase
{
    private readonly IDiscountService _discountService;

    public DiscountController(IDiscountService discountService)
    {
        _discountService = discountService;
    }

    [HttpGet]
    [ProducesResponseType(type: typeof(IEnumerable<DiscountResponseDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllDiscounts()
    {
        var discountList = await _discountService.GetAllDiscountsAsync();
        return Ok(discountList);
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(type: typeof(DiscountResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetDiscountById(int id)
    {
        var discount = await _discountService.GetDiscountByIdAsync(id);
        if (discount == null)
        {
            return NotFound();
        }
        return Ok(discount);
    }

    [HttpPost]
    [ProducesResponseType(type: typeof(DiscountResponseDto), StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateDiscount(DiscountRequestDto discount)
    {
        var createdDiscount = await _discountService.CreateDiscountAsync(discount);
        return CreatedAtAction(nameof(GetDiscountById), new { id = createdDiscount.Id }, createdDiscount);
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateDiscount(int id, DiscountRequestDto discount)
    {
        var updated = await _discountService.UpdateDiscountAsync(id, discount);
        if (!updated)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteDiscount(int id)
    {
        var deleted = await _discountService.DeleteDiscountAsync(id);
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }
}
