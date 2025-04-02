using Ebisx.POS.Api.Data;
using Ebisx.POS.Api.Entities;
using Ebisx.POS.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ebisx.POS.Api.Services;

public class UserRoleService : IUserRoleService
{
    private readonly ApplicationDbContext _dbContext;

    public UserRoleService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<UserRole>> GetAllRolesAsync()
    {
        return await _dbContext.UserRoles.ToListAsync();
    }

    public async Task<UserRole?> GetRoleByIdAsync(int id)
    {
        return await _dbContext.UserRoles.FindAsync(id);
    }

    public async Task<UserRole> CreateRoleAsync(UserRole role)
    {
        _dbContext.UserRoles.Add(role);
        await _dbContext.SaveChangesAsync();
        return role;
    }

    public async Task<bool> UpdateRoleAsync(int id, UserRole updatedRole)
    {
        var existingRole = await _dbContext.UserRoles.FindAsync(id);
        if (existingRole == null) return false;

        _dbContext.Entry(existingRole).CurrentValues.SetValues(updatedRole);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteRoleAsync(int id)
    {
        var role = await _dbContext.UserRoles.FindAsync(id);
        if (role == null) return false;

        _dbContext.UserRoles.Remove(role);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}