using Ebisx.POS.Api.Entities;
using Ebisx.POS.Api.Data;
using Ebisx.POS.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Ebisx.POS.Api.DTOs.DiscountType;

namespace Ebisx.POS.Api.Services;

/// <summary>
/// Service for managing discount types in the POS system.
/// </summary>
public class DiscountTypeService : IDiscountTypeService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="DiscountTypeService"/> class.
    /// </summary>
    /// <param name="dbContext">The database context for accessing discount type data.</param>
    /// <param name="mapper">The mapper for converting between entities and DTOs.</param>
    public DiscountTypeService(
        ApplicationDbContext dbContext,
        IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    /// <summary>
    /// Retrieves all discount types from the database.
    /// </summary>
    /// <returns>A collection of <see cref="DiscountTypeResponseDto"/> representing all discount types.</returns>
    public async Task<IEnumerable<DiscountTypeResponseDto>> GetAllDiscountTypesAsync()
    {
        try
        {
            var discountTypes = await _dbContext.DiscountTypes.ToListAsync();
            var discountTypeDtos = _mapper.Map<IEnumerable<DiscountTypeResponseDto>>(discountTypes);
            return discountTypeDtos;
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Retrieves specific discount type by its ID.
    /// </summary>
    /// <param name="id">The ID of the discount type to retrieve.</param>
    /// <returns>A <see cref="DiscountTypeResponseDto"/> representing the discount type, or null if not found.</returns>
    public async Task<DiscountTypeResponseDto?> GetDiscountTypeByIdAsync(int id)
    {
        try
        {
            var discountType = await _dbContext.DiscountTypes
                .FirstOrDefaultAsync(d => d.Id == id);

            if (discountType == null) return null;
            var discountTypeDto = _mapper.Map<DiscountTypeResponseDto>(discountType);
            return discountTypeDto;
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Creates a new discount type in the database.
    /// </summary>
    /// <param name="discountTypeDto">The <see cref="DiscountTypeRequestDto"/> containing discount type details.</param>
    /// <returns>The created <see cref="DiscountTypeResponseDto"/>.</returns>
    public async Task<DiscountTypeResponseDto> CreateDiscountTypeAsync(DiscountTypeRequestDto discountTypeDto)
    {
        try
        {
            var discountTypeEntity = _mapper.Map<DiscountType>(discountTypeDto);
            _dbContext.DiscountTypes.Add(discountTypeEntity);
            await _dbContext.SaveChangesAsync();

            var createdDiscountTypeDto = _mapper.Map<DiscountTypeResponseDto>(discountTypeEntity);
            return createdDiscountTypeDto;
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Updates an existing discount type in the database.
    /// </summary>
    /// <param name="id">The ID of the discount type to update.</param>
    /// <param name="updatedDiscountTypeDto">The updated discount type details.</param>
    /// <returns>True if the update was successful, false if the discount type was not found.</returns>
    public async Task<bool> UpdateDiscountTypeAsync(int id, DiscountTypeRequestDto updatedDiscountTypeDto)
    {
        try
        {
            var existingDiscountType = await _dbContext.DiscountTypes
                .FirstOrDefaultAsync(d => d.Id == id);

            if (existingDiscountType == null)
                return false;

            var existingEntry = _dbContext.Entry(existingDiscountType);
            existingEntry.CurrentValues.SetValues(updatedDiscountTypeDto);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Deletes a discount type from the database.
    /// </summary>
    /// <param name="id">The ID of the discount type to delete.</param>
    /// <returns>True if the deletion was successful, false if the discount type was not found.</returns>
    public async Task<bool> DeleteDiscountTypeAsync(int id)
    {
        try
        {
            var discountType = await _dbContext.DiscountTypes
                .FirstOrDefaultAsync(d => d.Id == id);

            if (discountType == null) return false;

            _dbContext.DiscountTypes.Remove(discountType);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch
        {
            throw;
        }
    }
}
