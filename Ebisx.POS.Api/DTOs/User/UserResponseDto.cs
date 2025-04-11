using Ebisx.POS.Api.DTOs.UserRole;

namespace Ebisx.POS.Api.DTOs.User;

public class UserResponseDto
{
    public int PrivateId { get; set; }
    public string PublicId { get; set; } = string.Empty;
    public string FName { get; set; } = string.Empty;
    public string LName { get; set; } = string.Empty;
    public string EmailAddress { get; set; } = string.Empty;
    public string? Address { get; set; }
    public DateTime BirthDate { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public UserRoleResponseDto? UserRole { get; set; }
}
