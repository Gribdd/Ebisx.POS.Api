using Ebisx.POS.Api.Entities;
using Ebisx.POS.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ebisx.POS.Api.Controllers
{
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
        public async Task<ActionResult<IEnumerable<SalesInvoice>>> GetAllSalesInvoices()
        {
            var salesInvoices = await _salesInvoiceService.GetAllSalesInvoicesAsync();
            return Ok(salesInvoices);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SalesInvoice>> GetSalesInvoiceById(int id)
        {
            var salesInvoice = await _salesInvoiceService.GetSalesInvoiceByIdAsync(id);
            if (salesInvoice == null)
            {
                return NotFound();
            }
            return Ok(salesInvoice);
        }

        [HttpPost]
        public async Task<ActionResult<SalesInvoice>> CreateSalesInvoice(SalesInvoice salesInvoice)
        {
            var createdSalesInvoice = await _salesInvoiceService.CreateSalesInvoiceAsync(salesInvoice);
            return CreatedAtAction(nameof(GetSalesInvoiceById), new { id = createdSalesInvoice.PrivateId }, createdSalesInvoice);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSalesInvoice(int id, SalesInvoice salesInvoice)
        {
            var updated = await _salesInvoiceService.UpdateSalesInvoiceAsync(id, salesInvoice);
            if (!updated)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
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
}
