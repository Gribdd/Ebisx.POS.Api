using Ebisx.POS.Api.DTOs.UserRole;

namespace Ebisx.POS.Api.Services.Interfaces;

public interface IUserRoleService
{
    Task<IEnumerable<UserRoleResponseDto>> GetAllRolesAsync();
    Task<UserRoleResponseDto?> GetRoleByIdAsync(int id);
    Task<UserRoleResponseDto> CreateRoleAsync(UserRoleRequestDto role);
    Task<bool> UpdateRoleAsync(int id, UserRoleRequestDto role);
    Task<bool> DeleteRoleAsync(int id);
}