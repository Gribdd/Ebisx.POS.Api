using Ebisx.POS.Api.Data;
using Ebisx.POS.Api.Entities;
using Ebisx.POS.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ebisx.POS.Api.Services
{
    public class SalesInvoiceService : ISalesInvoiceService
    {
        private readonly ApplicationDbContext _context;

        public SalesInvoiceService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SalesInvoice>> GetAllSalesInvoicesAsync()
        {
            return await _context.SalesInvoices.ToListAsync();
        }

        public async Task<SalesInvoice?> GetSalesInvoiceByIdAsync(int id)
        {
            return await _context.SalesInvoices.FindAsync(id);
        }

        public async Task<SalesInvoice> CreateSalesInvoiceAsync(SalesInvoice salesInvoice)
        {
            //generate a public id 
            _context.SalesInvoices.Add(salesInvoice);
            await _context.SaveChangesAsync();
            return salesInvoice;
        }

        public async Task<bool> UpdateSalesInvoiceAsync(int id, SalesInvoice salesInvoice)
        {
            var existingSalesInvoice = await _context.SalesInvoices.FindAsync(id);
            if (existingSalesInvoice == null)
            {
                return false;
            }

            _context.Entry(existingSalesInvoice).CurrentValues.SetValues(salesInvoice);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteSalesInvoiceAsync(int id)
        {
            var salesInvoice = await _context.SalesInvoices.FindAsync(id);
            if (salesInvoice == null)
            {
                return false;
            }

            _context.SalesInvoices.Remove(salesInvoice);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
