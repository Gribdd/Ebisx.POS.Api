using Ebisx.POS.Api.Entities;

namespace Ebisx.POS.Api.Services.Interfaces;

public interface IUserRoleService
{
    Task<IEnumerable<UserRole>> GetAllRolesAsync();
    Task<UserRole?> GetRoleByIdAsync(int id);
    Task<UserRole> CreateRoleAsync(UserRole role);
    Task<bool> UpdateRoleAsync(int id, UserRole role);
    Task<bool> DeleteRoleAsync(int id);
}