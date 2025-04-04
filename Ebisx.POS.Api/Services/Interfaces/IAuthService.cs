using Ebisx.POS.Api.Entities;

namespace Ebisx.POS.Api.Services.Interfaces;

public interface IAuthService
{
    Task<User> Login(string username, string password);
    Task<bool> UserExists(string username);
}