using Ebisx.POS.Api.Entities;
using Ebisx.POS.Api.Data;
using Ebisx.POS.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Ebisx.POS.Api.DTOs.BusinessInfo;
using AutoMapper;

namespace Ebisx.POS.Api.Services;

/// <summary>
/// Service for managing business information in the POS system.
/// </summary>
public class BusinessInfoService : IBusinessInfoService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="BusinessInfoService"/> class.
    /// </summary>
    /// <param name="dbContext">The database context for accessing business information data.</param>
    /// <param name="mapper">The mapper for converting between entities and DTOs.</param>
    public BusinessInfoService(
        ApplicationDbContext dbContext,
        IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    /// <summary>
    /// Retrieves all business information from the database.
    /// </summary>
    /// <returns>A collection of <see cref="BusinessInfoResponseDto"/> representing all business information.</returns>
    public async Task<IEnumerable<BusinessInfoResponseDto>> GetAllBusinessInfoAsync()
    {
        try
        {
            var businessInfos = await _dbContext.BusinessInfos.ToListAsync();
            var businessInfoDtos = _mapper.Map<IEnumerable<BusinessInfoResponseDto>>(businessInfos);
            return businessInfoDtos;
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Retrieves specific business information by its ID.
    /// </summary>
    /// <param name="id">The ID of the business information to retrieve.</param>
    /// <returns>A <see cref="BusinessInfoResponseDto"/> representing the business information, or null if not found.</returns>
    public async Task<BusinessInfoResponseDto?> GetBusinessInfoByIdAsync(int id)
    {
        try
        {
            var businessInfo = await _dbContext.BusinessInfos
                .FirstOrDefaultAsync(b => b.Id == id);

            if (businessInfo == null) return null;
            var businessInfoDto = _mapper.Map<BusinessInfoResponseDto>(businessInfo);
            return businessInfoDto;
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Creates new business information in the database.
    /// </summary>
    /// <param name="businessInfoDto">The <see cref="BusinessInfoRequestDto"/> containing business information details.</param>
    /// <returns>The created <see cref="BusinessInfoResponseDto"/>.</returns>
    public async Task<BusinessInfoResponseDto> CreateBusinessInfoAsync(BusinessInfoRequestDto businessInfoDto)
    {
        try
        {
            var businessInfoEntity = _mapper.Map<BusinessInfo>(businessInfoDto);
            _dbContext.BusinessInfos.Add(businessInfoEntity);
            await _dbContext.SaveChangesAsync();

            var createdBusinessInfoDto = _mapper.Map<BusinessInfoResponseDto>(businessInfoEntity);
            return createdBusinessInfoDto;
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Updates existing business information in the database.
    /// </summary>
    /// <param name="id">The ID of the business information to update.</param>
    /// <param name="updatedBusinessInfoDto">The updated business information details.</param>
    /// <returns>True if the update was successful, false if the business information was not found.</returns>
    public async Task<bool> UpdateBusinessInfoAsync(int id, BusinessInfoRequestDto updatedBusinessInfoDto)
    {
        try
        {
            var existingBusinessInfo = await _dbContext.BusinessInfos
                .FirstOrDefaultAsync(b => b.Id == id);

            if (existingBusinessInfo == null) 
                return false;

            var existingEntry = _dbContext.Entry(existingBusinessInfo);
            existingEntry.CurrentValues.SetValues(updatedBusinessInfoDto);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Deletes business information from the database.
    /// </summary>
    /// <param name="id">The ID of the business information to delete.</param>
    /// <returns>True if the deletion was successful, false if the business information was not found.</returns>
    public async Task<bool> DeleteBusinessInfoAsync(int id)
    {
        try
        {
            var businessInfo = await _dbContext.BusinessInfos
                .FirstOrDefaultAsync(b => b.Id == id);

            if (businessInfo == null) return false;

            _dbContext.BusinessInfos.Remove(businessInfo);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch
        {
            throw;
        }
    }
}
