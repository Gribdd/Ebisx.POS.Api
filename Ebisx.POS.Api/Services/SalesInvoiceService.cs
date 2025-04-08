using AutoMapper;
using Ebisx.POS.Api.Data;
using Ebisx.POS.Api.DTOs.SalesInvoice;
using Ebisx.POS.Api.Entities;
using Ebisx.POS.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ebisx.POS.Api.Services;

/// <summary>
/// Service for managing sales invoices in the POS system.
/// </summary>
public class SalesInvoiceService : ISalesInvoiceService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="SalesInvoiceService"/> class.
    /// </summary>
    /// <param name="dbContext">The database context for accessing sales invoice data.</param>
    /// <param name="mapper">The mapper for converting between entities and DTOs.</param>
    public SalesInvoiceService(
        ApplicationDbContext dbContext,
        IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    /// <summary>
    /// Retrieves all sales invoices from the database.
    /// </summary>
    /// <returns>A collection of <see cref="SalesInvoiceResponseDto"/> representing all sales invoices.</returns>
    public async Task<IEnumerable<SalesInvoiceResponseDto>> GetAllSalesInvoicesAsync()
    {
        try
        {
            var salesInvoices = await _dbContext.SalesInvoices.ToListAsync();
            var salesInvoiceDtos = _mapper.Map<IEnumerable<SalesInvoiceResponseDto>>(salesInvoices);
            return salesInvoiceDtos;
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Retrieves specific sales invoice by its ID.
    /// </summary>
    /// <param name="id">The ID of the sales invoice to retrieve.</param>
    /// <returns>A <see cref="SalesInvoiceResponseDto"/> representing the sales invoice, or null if not found.</returns>
    public async Task<SalesInvoiceResponseDto?> GetSalesInvoiceByIdAsync(int id)
    {
        try
        {
            var salesInvoice = await _dbContext.SalesInvoices
                .FirstOrDefaultAsync(s => s.PrivateId == id);

            if (salesInvoice == null) return null;
            var salesInvoiceDto = _mapper.Map<SalesInvoiceResponseDto>(salesInvoice);
            return salesInvoiceDto;
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Creates a new sales invoice in the database.
    /// </summary>
    /// <param name="salesInvoiceDto">The <see cref="SalesInvoiceRequestDto"/> containing sales invoice details.</param>
    /// <returns>The created <see cref="SalesInvoiceResponseDto"/>.</returns>
    public async Task<SalesInvoiceResponseDto> CreateSalesInvoiceAsync(SalesInvoiceRequestDto salesInvoiceDto)
    {
        try
        {
            var salesInvoiceEntity = _mapper.Map<SalesInvoice>(salesInvoiceDto);

            string datePart = DateTime.UtcNow.ToString("yyyyMMdd");

            // Get the latest invoice for the day to determine the next index
            var latestInvoice = await _dbContext.SalesInvoices
                .Where(i => i.PublicId.StartsWith(datePart))
                .OrderByDescending(i => i.PublicId)
                .FirstOrDefaultAsync();

            // Extract and increment the index
            int newIndex = 1; // Default index if none exist for the day
            if (latestInvoice != null)
            {
                string latestIndexStr = latestInvoice.PublicId.Substring(8); // Get part after the date
                if (int.TryParse(latestIndexStr, out int latestIndex))
                {
                    newIndex = latestIndex + 1;
                }
            }

            // Format the index as a 9-digit string (padded with zeros)
            string indexPart = newIndex.ToString("D5");

            // Generate the PublicId (e.g., "20240124-000000001")
            salesInvoiceEntity.PublicId = $"{datePart}-{indexPart}";

            _dbContext.SalesInvoices.Add(salesInvoiceEntity);
            await _dbContext.SaveChangesAsync();

            var createdSalesInvoiceDto = _mapper.Map<SalesInvoiceResponseDto>(salesInvoiceEntity);
            return createdSalesInvoiceDto;
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Updates existing sales invoice in the database.
    /// </summary>
    /// <param name="id">The ID of the sales invoice to update.</param>
    /// <param name="updatedSalesInvoiceDto">The updated sales invoice details.</param>
    /// <returns>True if the update was successful, false if the sales invoice was not found.</returns>
    public async Task<bool> UpdateSalesInvoiceAsync(int id, SalesInvoiceRequestDto updatedSalesInvoiceDto)
    {
        try
        {
            var existingSalesInvoice = await _dbContext.SalesInvoices
                .FirstOrDefaultAsync(s => s.PrivateId == id);

            if (existingSalesInvoice == null)
                return false;

            var existingEntry = _dbContext.Entry(existingSalesInvoice);
            existingEntry.CurrentValues.SetValues(updatedSalesInvoiceDto);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Deletes a sales invoice from the database.
    /// </summary>
    /// <param name="id">The ID of the sales invoice to delete.</param>
    /// <returns>True if the deletion was successful, false if the sales invoice was not found.</returns>
    public async Task<bool> DeleteSalesInvoiceAsync(int id)
    {
        try
        {
            var salesInvoice = await _dbContext.SalesInvoices
                .FirstOrDefaultAsync(s => s.PrivateId == id);

            if (salesInvoice == null) return false;

            _dbContext.SalesInvoices.Remove(salesInvoice);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch
        {
            throw;
        }
    }
}
