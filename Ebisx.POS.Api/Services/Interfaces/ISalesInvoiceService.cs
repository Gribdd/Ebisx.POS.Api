using Ebisx.POS.Api.DTOs.SalesInvoice;

namespace Ebisx.POS.Api.Services.Interfaces;

public interface ISalesInvoiceService
{
    Task<IEnumerable<SalesInvoiceResponseDto>> GetAllSalesInvoicesAsync();
    Task<SalesInvoiceResponseDto?> GetSalesInvoiceByIdAsync(int id);
    Task<SalesInvoiceResponseDto> CreateSalesInvoiceAsync(SalesInvoiceRequestDto salesInvoice);
    Task<bool> UpdateSalesInvoiceAsync(int id, SalesInvoiceRequestDto salesInvoice);
    Task<bool> DeleteSalesInvoiceAsync(int id);
}
