using Ebisx.POS.Api.DTOs.User;

namespace Ebisx.POS.Api.Services.Interfaces;

public interface IUserService
{
    Task<IEnumerable<UserResponseDto>> GetAllUsersAsync();
    Task<UserResponseDto?> GetUserByIdAsync(int privateId);  // Changed to int for PrivateId
    Task<UserResponseDto> CreateUserAsync(UserRequestDto user);
    Task<bool> UpdateUserAsync(int privateId, UserRequestDto user);  // Changed to int for PrivateId
    Task<bool> DeleteUserAsync(int privateId);  // Changed to int for PrivateId
}