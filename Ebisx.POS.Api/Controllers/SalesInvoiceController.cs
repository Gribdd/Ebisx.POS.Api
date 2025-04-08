using Ebisx.POS.Api.DTOs.SalesInvoice;
using Ebisx.POS.Api.Entities;
using Ebisx.POS.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ebisx.POS.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SalesInvoiceController : ControllerBase
{
    private readonly ISalesInvoiceService _salesInvoiceService;

    public SalesInvoiceController(ISalesInvoiceService salesInvoiceService)
    {
        _salesInvoiceService = salesInvoiceService;
    }

    [HttpGet]
    [ProducesResponseType(type: typeof(IEnumerable<SalesInvoiceResponseDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllSalesInvoices()
    {
        var salesInvoices = await _salesInvoiceService.GetAllSalesInvoicesAsync();
        return Ok(salesInvoices);
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(type: typeof(SalesInvoiceResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetSalesInvoiceById(int id)
    {
        var salesInvoice = await _salesInvoiceService.GetSalesInvoiceByIdAsync(id);
        if (salesInvoice == null)
        {
            return NotFound();
        }
        return Ok(salesInvoice);
    }

    [HttpPost]
    [ProducesResponseType(type: typeof(SalesInvoiceResponseDto), StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateSalesInvoice(SalesInvoiceRequestDto salesInvoice)
    {
        var createdSalesInvoice = await _salesInvoiceService.CreateSalesInvoiceAsync(salesInvoice);
        return CreatedAtAction(nameof(GetSalesInvoiceById), new { id = createdSalesInvoice.PrivateId }, createdSalesInvoice);
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateSalesInvoice(int id, SalesInvoiceRequestDto salesInvoice)
    {
        var updated = await _salesInvoiceService.UpdateSalesInvoiceAsync(id, salesInvoice);
        if (!updated)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteSalesInvoice(int id)
    {
        var deleted = await _salesInvoiceService.DeleteSalesInvoiceAsync(id);
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }
}
