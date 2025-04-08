using AutoMapper;
using Ebisx.POS.Api.Data;
using Ebisx.POS.Api.DTOs.User;
using Ebisx.POS.Api.Entities;
using Ebisx.POS.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ebisx.POS.Api.Services;

/// <summary>  
/// Service for managing user information in the POS system.  
/// </summary>  
public class UserService : IUserService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    /// <summary>  
    /// Initializes a new instance of the <see cref="UserService"/> class.  
    /// </summary>  
    /// <param name="dbContext">The database context for accessing user data.</param>  
    /// <param name="mapper">The mapper for converting between entities and DTOs.</param>  
    public UserService(
        ApplicationDbContext dbContext,
        IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    /// <summary>  
    /// Retrieves all users from the database.  
    /// </summary>  
    /// <returns>A collection of <see cref="UserResponseDto"/> representing all users.</returns>  
    public async Task<IEnumerable<UserResponseDto>> GetAllUsersAsync()
    {
        try
        {
            var users = await _dbContext.Users.Include(u => u.UserRole).ToListAsync();
            var userDtos = _mapper.Map<IEnumerable<UserResponseDto>>(users);
            return userDtos;
        }
        catch
        {
            throw;
        }
    }

    /// <summary>  
    /// Retrieves a specific user by their private ID.  
    /// </summary>  
    /// <param name="privateId">The private ID of the user to retrieve.</param>  
    /// <returns>A <see cref="UserResponseDto"/> representing the user, or null if not found.</returns>  
    public async Task<UserResponseDto?> GetUserByIdAsync(int privateId)
    {
        try
        {
            var user = await _dbContext.Users
                .Include(u => u.UserRole)
                .FirstOrDefaultAsync(u => u.PrivateId == privateId);

            if (user == null) return null;
            var userDto = _mapper.Map<UserResponseDto>(user);
            return userDto;
        }
        catch
        {
            throw;
        }
    }

    /// <summary>  
    /// Creates a new user in the database.  
    /// </summary>  
    /// <param name="userDto">The <see cref="UserRequestDto"/> containing user details.</param>  
    /// <returns>The created <see cref="UserResponseDto"/>.</returns>  
    public async Task<UserResponseDto> CreateUserAsync(UserRequestDto userDto)
    {
        try
        {
            var userEntity = _mapper.Map<User>(userDto);
            userEntity.PublicId = $"USR-{Guid.NewGuid().ToString().Substring(0, 8).ToUpper()}";
            _dbContext.Users.Add(userEntity);
            await _dbContext.SaveChangesAsync();

            var createdUserDto = _mapper.Map<UserResponseDto>(userEntity);
            return createdUserDto;
        }
        catch
        {
            throw;
        }
    }

    /// <summary>  
    /// Updates an existing user in the database.  
    /// </summary>  
    /// <param name="privateId">The private ID of the user to update.</param>  
    /// <param name="updatedUserDto">The updated user details.</param>  
    /// <returns>True if the update was successful, false if the user was not found.</returns>  
    public async Task<bool> UpdateUserAsync(int privateId, UserRequestDto updatedUserDto)
    {
        try
        {
            var existingUser = await _dbContext.Users
                .FirstOrDefaultAsync(u => u.PrivateId == privateId);

            if (existingUser == null)
                return false;

            var existingEntry = _dbContext.Entry(existingUser);
            existingEntry.CurrentValues.SetValues(updatedUserDto);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch
        {
            throw;
        }
    }

    /// <summary>  
    /// Deletes a user from the database.  
    /// </summary>  
    /// <param name="privateId">The private ID of the user to delete.</param>  
    /// <returns>True if the deletion was successful, false if the user was not found.</returns>  
    public async Task<bool> DeleteUserAsync(int privateId)
    {
        try
        {
            var user = await _dbContext.Users
                .FirstOrDefaultAsync(u => u.PrivateId == privateId);

            if (user == null) return false;

            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch
        {
            throw;
        }
    }
}
