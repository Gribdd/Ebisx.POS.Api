using Ebisx.POS.Api.Entities;
using Ebisx.POS.Api.Data;
using Ebisx.POS.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Ebisx.POS.Api.DTOs.NonCashPaymentMethod;
using AutoMapper;

namespace Ebisx.POS.Api.Services;

/// <summary>
/// Service for managing non-cash payment methods in the POS system.
/// </summary>
public class NonCashPaymentMethodService : INonCashPaymentMethodService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="NonCashPaymentMethodService"/> class.
    /// </summary>
    /// <param name="dbContext">The database context for accessing non-cash payment method data.</param>
    /// <param name="mapper">The mapper for converting between entities and DTOs.</param>
    public NonCashPaymentMethodService(
        ApplicationDbContext dbContext,
        IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    /// <summary>
    /// Retrieves all non-cash payment methods from the database.
    /// </summary>
    /// <returns>A collection of <see cref="NonCashPaymentMethodResponseDto"/> representing all non-cash payment methods.</returns>
    public async Task<IEnumerable<NonCashPaymentMethodResponseDto>> GetAllNonCashPaymentMethodsAsync()
    {
        try
        {
            var nonCashPaymentMethods = await _dbContext.NonCashPaymentMethods.ToListAsync();
            var nonCashPaymentMethodDtos = _mapper.Map<IEnumerable<NonCashPaymentMethodResponseDto>>(nonCashPaymentMethods);
            return nonCashPaymentMethodDtos;
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Retrieves specific non-cash payment method by its ID.
    /// </summary>
    /// <param name="id">The ID of the non-cash payment method to retrieve.</param>
    /// <returns>A <see cref="NonCashPaymentMethodResponseDto"/> representing the non-cash payment method, or null if not found.</returns>
    public async Task<NonCashPaymentMethodResponseDto?> GetNonCashPaymentMethodByIdAsync(int id)
    {
        try
        {
            var nonCashPaymentMethod = await _dbContext.NonCashPaymentMethods
                .FirstOrDefaultAsync(n => n.Id == id);

            if (nonCashPaymentMethod == null) return null;
            var nonCashPaymentMethodDto = _mapper.Map<NonCashPaymentMethodResponseDto>(nonCashPaymentMethod);
            return nonCashPaymentMethodDto;
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Creates a new non-cash payment method in the database.
    /// </summary>
    /// <param name="nonCashPaymentMethodDto">The <see cref="NonCashPaymentMethodRequestDto"/> containing non-cash payment method details.</param>
    /// <returns>The created <see cref="NonCashPaymentMethodResponseDto"/>.</returns>
    public async Task<NonCashPaymentMethodResponseDto> CreateNonCashPaymentMethodAsync(NonCashPaymentMethodRequestDto nonCashPaymentMethodDto)
    {
        try
        {
            var nonCashPaymentMethodEntity = _mapper.Map<NonCashPaymentMethod>(nonCashPaymentMethodDto);
            _dbContext.NonCashPaymentMethods.Add(nonCashPaymentMethodEntity);
            await _dbContext.SaveChangesAsync();

            var createdNonCashPaymentMethodDto = _mapper.Map<NonCashPaymentMethodResponseDto>(nonCashPaymentMethodEntity);
            return createdNonCashPaymentMethodDto;
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Updates an existing non-cash payment method in the database.
    /// </summary>
    /// <param name="id">The ID of the non-cash payment method to update.</param>
    /// <param name="updatedNonCashPaymentMethodDto">The updated non-cash payment method details.</param>
    /// <returns>True if the update was successful, false if the non-cash payment method was not found.</returns>
    public async Task<bool> UpdateNonCashPaymentMethodAsync(int id, NonCashPaymentMethodRequestDto updatedNonCashPaymentMethodDto)
    {
        try
        {
            var existingNonCashPaymentMethod = await _dbContext.NonCashPaymentMethods
                .FirstOrDefaultAsync(n => n.Id == id);

            if (existingNonCashPaymentMethod == null)
                return false;

            var existingEntry = _dbContext.Entry(existingNonCashPaymentMethod);
            existingEntry.CurrentValues.SetValues(updatedNonCashPaymentMethodDto);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Deletes a non-cash payment method from the database.
    /// </summary>
    /// <param name="id">The ID of the non-cash payment method to delete.</param>
    /// <returns>True if the deletion was successful, false if the non-cash payment method was not found.</returns>
    public async Task<bool> DeleteNonCashPaymentMethodAsync(int id)
    {
        try
        {
            var nonCashPaymentMethod = await _dbContext.NonCashPaymentMethods
                .FirstOrDefaultAsync(n => n.Id == id);

            if (nonCashPaymentMethod == null) return false;

            _dbContext.NonCashPaymentMethods.Remove(nonCashPaymentMethod);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch
        {
            throw;
        }
    }
}
