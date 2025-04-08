using Ebisx.POS.Api.Entities;
using Ebisx.POS.Api.Data;
using Ebisx.POS.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Ebisx.POS.Api.DTOs.PaymentType;

namespace Ebisx.POS.Api.Services;

/// <summary>
/// Service for managing payment types in the POS system.
/// </summary>
public class PaymentTypeService : IPaymentTypeService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="PaymentTypeService"/> class.
    /// </summary>
    /// <param name="dbContext">The database context for accessing payment type data.</param>
    /// <param name="mapper">The mapper for converting between entities and DTOs.</param>
    public PaymentTypeService(
        ApplicationDbContext dbContext,
        IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    /// <summary>
    /// Retrieves all payment types from the database.
    /// </summary>
    /// <returns>A collection of <see cref="PaymentTypeResponseDto"/> representing all payment types.</returns>
    public async Task<IEnumerable<PaymentTypeResponseDto>> GetAllPaymentTypesAsync()
    {
        try
        {
            var paymentTypes = await _dbContext.PaymentTypes.ToListAsync();
            var paymentTypeDtos = _mapper.Map<IEnumerable<PaymentTypeResponseDto>>(paymentTypes);
            return paymentTypeDtos;
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Retrieves a specific payment type by its ID.
    /// </summary>
    /// <param name="id">The ID of the payment type to retrieve.</param>
    /// <returns>A <see cref="PaymentTypeResponseDto"/> representing the payment type, or null if not found.</returns>
    public async Task<PaymentTypeResponseDto?> GetPaymentTypeByIdAsync(int id)
    {
        try
        {
            var paymentType = await _dbContext.PaymentTypes
                .FirstOrDefaultAsync(p => p.Id == id);

            if (paymentType == null) return null;
            var paymentTypeDto = _mapper.Map<PaymentTypeResponseDto>(paymentType);
            return paymentTypeDto;
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Creates a new payment type in the database.
    /// </summary>
    /// <param name="paymentTypeDto">The <see cref="PaymentTypeRequestDto"/> containing payment type details.</param>
    /// <returns>The created <see cref="PaymentTypeResponseDto"/>.</returns>
    public async Task<PaymentTypeResponseDto> CreatePaymentTypeAsync(PaymentTypeRequestDto paymentTypeDto)
    {
        try
        {
            var paymentTypeEntity = _mapper.Map<PaymentType>(paymentTypeDto);
            _dbContext.PaymentTypes.Add(paymentTypeEntity);
            await _dbContext.SaveChangesAsync();

            var createdPaymentTypeDto = _mapper.Map<PaymentTypeResponseDto>(paymentTypeEntity);
            return createdPaymentTypeDto;
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Updates an existing payment type in the database.
    /// </summary>
    /// <param name="id">The ID of the payment type to update.</param>
    /// <param name="updatedPaymentTypeDto">The updated payment type details.</param>
    /// <returns>True if the update was successful, false if the payment type was not found.</returns>
    public async Task<bool> UpdatePaymentTypeAsync(int id, PaymentTypeRequestDto updatedPaymentTypeDto)
    {
        try
        {
            var existingPaymentType = await _dbContext.PaymentTypes
                .FirstOrDefaultAsync(p => p.Id == id);

            if (existingPaymentType == null)
                return false;

            var existingEntry = _dbContext.Entry(existingPaymentType);
            existingEntry.CurrentValues.SetValues(updatedPaymentTypeDto);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Deletes a payment type from the database.
    /// </summary>
    /// <param name="id">The ID of the payment type to delete.</param>
    /// <returns>True if the deletion was successful, false if the payment type was not found.</returns>
    public async Task<bool> DeletePaymentTypeAsync(int id)
    {
        try
        {
            var paymentType = await _dbContext.PaymentTypes
                .FirstOrDefaultAsync(p => p.Id == id);

            if (paymentType == null) return false;

            _dbContext.PaymentTypes.Remove(paymentType);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch
        {
            throw;
        }
    }
}
