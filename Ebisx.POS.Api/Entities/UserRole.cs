using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ebisx.POS.Api.Entities;

/// <summary>
/// Represents a user role within the system.
/// </summary>
[Index(nameof(Role), IsUnique = true)]
public class UserRole
{
    /// <summary>
    /// Gets or sets the unique identifier for the user role.
    /// </summary>
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the role.
    /// </summary>
    [Required]
    public string Role { get; set; } = string.Empty;
}
