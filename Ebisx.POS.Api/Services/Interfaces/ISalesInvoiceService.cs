using Ebisx.POS.Api.Entities;

namespace Ebisx.POS.Api.Services.Interfaces
{
    public interface ISalesInvoiceService
    {
        Task<IEnumerable<SalesInvoice>> GetAllSalesInvoicesAsync();
        Task<SalesInvoice?> GetSalesInvoiceByIdAsync(int id);
        Task<SalesInvoice> CreateSalesInvoiceAsync(SalesInvoice salesInvoice);
        Task<bool> UpdateSalesInvoiceAsync(int id, SalesInvoice salesInvoice);
        Task<bool> DeleteSalesInvoiceAsync(int id);
    }
}
