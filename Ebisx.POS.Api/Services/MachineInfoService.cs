using Ebisx.POS.Api.Entities;
using Ebisx.POS.Api.Data;
using Ebisx.POS.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Ebisx.POS.Api.DTOs.MachineInfo;

namespace Ebisx.POS.Api.Services;

/// <summary>
/// Service for managing machine information in the POS system.
/// </summary>
public class MachineInfoService : IMachineInfoService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="MachineInfoService"/> class.
    /// </summary>
    /// <param name="dbContext">The database context for accessing machine information data.</param>
    /// <param name="mapper">The mapper for converting between entities and DTOs.</param>
    public MachineInfoService(
        ApplicationDbContext dbContext,
        IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    /// <summary>
    /// Retrieves all machine information from the database.
    /// </summary>
    /// <returns>A collection of <see cref="MachineInfoResponseDto"/> representing all machine information.</returns>
    public async Task<IEnumerable<MachineInfoResponseDto>> GetAllMachineInfoAsync()
    {
        try
        {
            var machineInfos = await _dbContext.MachineInfos.ToListAsync();
            var machineInfoDtos = _mapper.Map<IEnumerable<MachineInfoResponseDto>>(machineInfos);
            return machineInfoDtos;
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Retrieves specific machine information by its ID.
    /// </summary>
    /// <param name="id">The ID of the machine information to retrieve.</param>
    /// <returns>A <see cref="MachineInfoResponseDto"/> representing the machine information, or null if not found.</returns>
    public async Task<MachineInfoResponseDto?> GetMachineInfoByIdAsync(int id)
    {
        try
        {
            var machineInfo = await _dbContext.MachineInfos
                .FirstOrDefaultAsync(m => m.Id == id);

            if (machineInfo == null) return null;
            var machineInfoDto = _mapper.Map<MachineInfoResponseDto>(machineInfo);
            return machineInfoDto;
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Creates new machine information in the database.
    /// </summary>
    /// <param name="machineInfoDto">The <see cref="MachineInfoRequestDto"/> containing machine information details.</param>
    /// <returns>The created <see cref="MachineInfoResponseDto"/>.</returns>
    public async Task<MachineInfoResponseDto> CreateMachineInfoAsync(MachineInfoRequestDto machineInfoDto)
    {
        try
        {
            var machineInfoEntity = _mapper.Map<MachineInfo>(machineInfoDto);
            _dbContext.MachineInfos.Add(machineInfoEntity);
            await _dbContext.SaveChangesAsync();

            var createdMachineInfoDto = _mapper.Map<MachineInfoResponseDto>(machineInfoEntity);
            return createdMachineInfoDto;
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Updates existing machine information in the database.
    /// </summary>
    /// <param name="id">The ID of the machine information to update.</param>
    /// <param name="updatedMachineInfoDto">The updated machine information details.</param>
    /// <returns>True if the update was successful, false if the machine information was not found.</returns>
    public async Task<bool> UpdateMachineInfoAsync(int id, MachineInfoRequestDto updatedMachineInfoDto)
    {
        try
        {
            var existingMachineInfo = await _dbContext.MachineInfos
                .FirstOrDefaultAsync(m => m.Id == id);

            if (existingMachineInfo == null)
                return false;

            var existingEntry = _dbContext.Entry(existingMachineInfo);
            existingEntry.CurrentValues.SetValues(updatedMachineInfoDto);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Deletes machine information from the database.
    /// </summary>
    /// <param name="id">The ID of the machine information to delete.</param>
    /// <returns>True if the deletion was successful, false if the machine information was not found.</returns>
    public async Task<bool> DeleteMachineInfoAsync(int id)
    {
        try
        {
            var machineInfo = await _dbContext.MachineInfos
                .FirstOrDefaultAsync(m => m.Id == id);

            if (machineInfo == null) return false;

            _dbContext.MachineInfos.Remove(machineInfo);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch
        {
            throw;
        }
    }
}
