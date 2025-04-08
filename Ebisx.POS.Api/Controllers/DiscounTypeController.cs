using Ebisx.POS.Api.DTOs.DiscountType;
using Ebisx.POS.Api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ebisx.POS.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DiscounTypeController : ControllerBase
{
    private readonly IDiscountTypeService _discountTypeService;

    public DiscounTypeController(IDiscountTypeService discountTypeService)
    {
        _discountTypeService = discountTypeService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DiscountTypeResponseDto>>> GetAllDiscountTypes()
    {
        var discountTypeList = await _discountTypeService.GetAllDiscountTypesAsync();
        return Ok(discountTypeList);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<DiscountTypeResponseDto>> GetDiscountTypeById(int id)
    {
        var discountType = await _discountTypeService.GetDiscountTypeByIdAsync(id);
        if (discountType == null)
        {
            return NotFound();
        }
        return Ok(discountType);
    }

    [HttpPost]
    public async Task<ActionResult<DiscountTypeResponseDto>> CreateDiscountType(DiscountTypeRequestDto discountType)
    {
        var createdDiscountType = await _discountTypeService.CreateDiscountTypeAsync(discountType);
        return CreatedAtAction(nameof(GetDiscountTypeById), new { id = createdDiscountType.Id }, createdDiscountType);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateDiscountType(int id, DiscountTypeRequestDto discountType)
    {
        var updated = await _discountTypeService.UpdateDiscountTypeAsync(id, discountType);
        if (!updated)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteDiscountType(int id)
    {
        var deleted = await _discountTypeService.DeleteDiscountTypeAsync(id);
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }
}
