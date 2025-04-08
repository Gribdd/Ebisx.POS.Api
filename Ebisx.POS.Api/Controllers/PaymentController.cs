using Ebisx.POS.Api.DTOs.Payment;
using Ebisx.POS.Api.Entities;
using Ebisx.POS.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ebisx.POS.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PaymentController : ControllerBase
{
    private readonly IPaymentService _paymentService;

    public PaymentController(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PaymentResponseDto>>> GetAllPayments()
    {
        var payments = await _paymentService.GetAllPaymentsAsync();
        return Ok(payments);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<PaymentResponseDto>> GetPaymentById(int id)
    {
        var payment = await _paymentService.GetPaymentByIdAsync(id);
        if (payment == null)
        {
            return NotFound();
        }
        return Ok(payment);
    }

    [HttpPost]
    public async Task<ActionResult<PaymentResponseDto>> CreatePayment(PaymentRequestDto payment)
    {
        var createdPayment = await _paymentService.CreatePaymentAsync(payment);
        return CreatedAtAction(nameof(GetPaymentById), new { id = createdPayment.Id }, createdPayment);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdatePayment(int id, PaymentRequestDto payment)
    {
        var updated = await _paymentService.UpdatePaymentAsync(id, payment);
        if (!updated)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeletePayment(int id)
    {
        var deleted = await _paymentService.DeletePaymentAsync(id);
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }
}
