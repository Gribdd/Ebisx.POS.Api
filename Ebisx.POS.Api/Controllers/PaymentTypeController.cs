using Ebisx.POS.Api.DTOs.PaymentType;
using Ebisx.POS.Api.Entities;
using Ebisx.POS.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ebisx.POS.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PaymentTypeController : ControllerBase
{
    private readonly IPaymentTypeService _paymentTypeService;

    public PaymentTypeController(IPaymentTypeService paymentTypeService)
    {
        _paymentTypeService = paymentTypeService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PaymentTypeResponseDto>>> GetAllPaymentTypes()
    {
        var paymentTypes = await _paymentTypeService.GetAllPaymentTypesAsync();
        return Ok(paymentTypes);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<PaymentTypeResponseDto>> GetPaymentTypeById(int id)
    {
        var paymentType = await _paymentTypeService.GetPaymentTypeByIdAsync(id);
        if (paymentType == null)
        {
            return NotFound();
        }
        return Ok(paymentType);
    }

    [HttpPost]
    public async Task<ActionResult<PaymentTypeResponseDto>> CreatePaymentType(PaymentTypeRequestDto paymentType)
    {
        var createdPaymentType = await _paymentTypeService.CreatePaymentTypeAsync(paymentType);
        return CreatedAtAction(nameof(GetPaymentTypeById), new { id = createdPaymentType.Id }, createdPaymentType);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdatePaymentType(int id, PaymentTypeRequestDto paymentType)
    {
        var updated = await _paymentTypeService.UpdatePaymentTypeAsync(id, paymentType);
        if (!updated)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeletePaymentType(int id)
    {
        var deleted = await _paymentTypeService.DeletePaymentTypeAsync(id);
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }
}
