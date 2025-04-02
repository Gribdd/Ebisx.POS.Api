using Ebisx.POS.Api.Entities;

namespace Ebisx.POS.Api.Services.Interfaces;

public interface IUserService
{
    Task<IEnumerable<User>> GetAllUsersAsync();
    Task<User?> GetUserByIdAsync(int privateId);  // Changed to int for PrivateId
    Task<User> CreateUserAsync(User user);
    Task<bool> UpdateUserAsync(int privateId, User user);  // Changed to int for PrivateId
    Task<bool> DeleteUserAsync(int privateId);  // Changed to int for PrivateId
}