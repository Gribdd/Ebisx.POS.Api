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
    public async Task<ActionResult<IEnumerable<DiscountResponseDto>>> GetAllDiscounts()
    {
        var discountList = await _discountService.GetAllDiscountsAsync();
        return Ok(discountList);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<DiscountResponseDto>> GetDiscountById(int id)
    {
        var discount = await _discountService.GetDiscountByIdAsync(id);
        if (discount == null)
        {
            return NotFound();
        }
        return Ok(discount);
    }

    [HttpPost]
    public async Task<ActionResult<DiscountResponseDto>> CreateDiscount(DiscountRequestDto discount)
    {
        var createdDiscount = await _discountService.CreateDiscountAsync(discount);
        return CreatedAtAction(nameof(GetDiscountById), new { id = createdDiscount.Id }, createdDiscount);
    }

    [HttpPut("{id:int}")]
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
