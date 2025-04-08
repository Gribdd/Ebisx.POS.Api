using AutoMapper;
using Ebisx.POS.Api.Data;
using Ebisx.POS.Api.DTOs.UserRole;
using Ebisx.POS.Api.Entities;
using Ebisx.POS.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ebisx.POS.Api.Services;

/// <summary>
/// Service for managing user roles in the POS system.
/// </summary>
public class UserRoleService : IUserRoleService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="UserRoleService"/> class.
    /// </summary>
    /// <param name="dbContext">The database context for accessing user role data.</param>
    /// <param name="mapper">The mapper for converting between entities and DTOs.</param>
    public UserRoleService(
        ApplicationDbContext dbContext,
        IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    /// <summary>
    /// Retrieves all user roles from the database.
    /// </summary>
    /// <returns>A collection of <see cref="UserRoleResponseDto"/> representing all user roles.</returns>
    public async Task<IEnumerable<UserRoleResponseDto>> GetAllRolesAsync()
    {
        try
        {
            var roles = await _dbContext.UserRoles.ToListAsync();
            var roleDtos = _mapper.Map<IEnumerable<UserRoleResponseDto>>(roles);
            return roleDtos;
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Retrieves a specific user role by its ID.
    /// </summary>
    /// <param name="id">The ID of the user role to retrieve.</param>
    /// <returns>A <see cref="UserRoleResponseDto"/> representing the user role, or null if not found.</returns>
    public async Task<UserRoleResponseDto?> GetRoleByIdAsync(int id)
    {
        try
        {
            var role = await _dbContext.UserRoles.FirstOrDefaultAsync(r => r.Id == id);

            if (role == null) return null;
            var roleDto = _mapper.Map<UserRoleResponseDto>(role);
            return roleDto;
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Creates a new user role in the database.
    /// </summary>
    /// <param name="roleDto">The <see cref="UserRoleRequestDto"/> containing user role details.</param>
    /// <returns>The created <see cref="UserRoleResponseDto"/>.</returns>
    public async Task<UserRoleResponseDto> CreateRoleAsync(UserRoleRequestDto roleDto)
    {
        try
        {
            var roleEntity = _mapper.Map<UserRole>(roleDto);
            _dbContext.UserRoles.Add(roleEntity);
            await _dbContext.SaveChangesAsync();

            var createdRoleDto = _mapper.Map<UserRoleResponseDto>(roleEntity);
            return createdRoleDto;
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Updates an existing user role in the database.
    /// </summary>
    /// <param name="id">The ID of the user role to update.</param>
    /// <param name="updatedRoleDto">The updated user role details.</param>
    /// <returns>True if the update was successful, false if the user role was not found.</returns>
    public async Task<bool> UpdateRoleAsync(int id, UserRoleRequestDto updatedRoleDto)
    {
        try
        {
            var existingRole = await _dbContext.UserRoles.FirstOrDefaultAsync(r => r.Id == id);

            if (existingRole == null)
                return false;

            var existingEntry = _dbContext.Entry(existingRole);
            existingEntry.CurrentValues.SetValues(updatedRoleDto);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Deletes a user role from the database.
    /// </summary>
    /// <param name="id">The ID of the user role to delete.</param>
    /// <returns>True if the deletion was successful, false if the user role was not found.</returns>
    public async Task<bool> DeleteRoleAsync(int id)
    {
        try
        {
            var role = await _dbContext.UserRoles.FirstOrDefaultAsync(r => r.Id == id);

            if (role == null) return false;

            _dbContext.UserRoles.Remove(role);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch
        {
            throw;
        }
    }
}
