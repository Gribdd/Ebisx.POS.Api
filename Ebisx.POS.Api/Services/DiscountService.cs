using Ebisx.POS.Api.Entities;
using Ebisx.POS.Api.Data;
using Ebisx.POS.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Ebisx.POS.Api.DTOs.Discount;

namespace Ebisx.POS.Api.Services;

/// <summary>
/// Service for managing discounts in the POS system.
/// </summary>
public class DiscountService : IDiscountService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="DiscountService"/> class.
    /// </summary>
    /// <param name="dbContext">The database context for accessing discount data.</param>
    /// <param name="mapper">The mapper for converting between entities and DTOs.</param>
    public DiscountService(
        ApplicationDbContext dbContext,
        IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    /// <summary>
    /// Retrieves all discounts from the database.
    /// </summary>
    /// <returns>A collection of <see cref="DiscountResponseDto"/> representing all discounts.</returns>
    public async Task<IEnumerable<DiscountResponseDto>> GetAllDiscountsAsync()
    {
        try
        {
            var discounts = await _dbContext.Discounts.Include(d => d.DiscountType).ToListAsync();
            var discountDtos = _mapper.Map<IEnumerable<DiscountResponseDto>>(discounts);
            return discountDtos;
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Retrieves specific discount by its ID.
    /// </summary>
    /// <param name="id">The ID of the discount to retrieve.</param>
    /// <returns>A <see cref="DiscountResponseDto"/> representing the discount, or null if not found.</returns>
    public async Task<DiscountResponseDto?> GetDiscountByIdAsync(int id)
    {
        try
        {
            var discount = await _dbContext.Discounts
                .Include(d => d.DiscountType)
                .FirstOrDefaultAsync(d => d.Id == id);

            if (discount == null) return null;
            var discountDto = _mapper.Map<DiscountResponseDto>(discount);
            return discountDto;
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Creates a new discount in the database.
    /// </summary>
    /// <param name="discountDto">The <see cref="DiscountRequestDto"/> containing discount details.</param>
    /// <returns>The created <see cref="DiscountResponseDto"/>.</returns>
    public async Task<DiscountResponseDto> CreateDiscountAsync(DiscountRequestDto discountDto)
    {
        try
        {
            var discountEntity = _mapper.Map<Discount>(discountDto);
            _dbContext.Discounts.Add(discountEntity);
            await _dbContext.SaveChangesAsync();

            var createdDiscountDto = _mapper.Map<DiscountResponseDto>(discountEntity);
            return createdDiscountDto;
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Updates existing discount in the database.
    /// </summary>
    /// <param name="id">The ID of the discount to update.</param>
    /// <param name="updatedDiscountDto">The updated discount details.</param>
    /// <returns>True if the update was successful, false if the discount was not found.</returns>
    public async Task<bool> UpdateDiscountAsync(int id, DiscountRequestDto updatedDiscountDto)
    {
        try
        {
            var existingDiscount = await _dbContext.Discounts
                .FirstOrDefaultAsync(d => d.Id == id);

            if (existingDiscount == null)
                return false;

            var existingEntry = _dbContext.Entry(existingDiscount);
            existingEntry.CurrentValues.SetValues(updatedDiscountDto);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Deletes a discount from the database.
    /// </summary>
    /// <param name="id">The ID of the discount to delete.</param>
    /// <returns>True if the deletion was successful, false if the discount was not found.</returns>
    public async Task<bool> DeleteDiscountAsync(int id)
    {
        try
        {
            var discount = await _dbContext.Discounts
                .FirstOrDefaultAsync(d => d.Id == id);

            if (discount == null) return false;

            _dbContext.Discounts.Remove(discount);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch
        {
            throw;
        }
    }
}
