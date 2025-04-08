using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ebisx.POS.Api.Entities;
/// <summary>
/// Represents a user entity with personal and authentication details.
/// </summary>
[Index(nameof(EmailAddress), IsUnique = true)]
[Index(nameof(Username), IsUnique = true)]
public class User
{
    /// <summary>
    /// Gets or sets the private identifier for the user.
    /// </summary>
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PrivateId { get; set; }

    /// <summary>
    /// Gets or sets the public identifier for the user.
    /// </summary>
    [MaxLength(20)]
    public string PublicId { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the first name of the user.
    /// </summary>
    [Required]
    public string FName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the last name of the user.
    /// </summary>
    [Required]
    public string LName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the email address of the user.
    /// </summary>
    [Required]
    public string EmailAddress { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the address of the user.
    /// </summary>
    public string? Address { get; set; }

    /// <summary>
    /// Gets or sets the birth date of the user.
    /// </summary>
    public DateTime BirthDate { get; set; }

    /// <summary>
    /// Gets or sets the username of the user.
    /// </summary>
    [Required]
    public string Username { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the password of the user.
    /// </summary>
    [Required]
    public string Password { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the role identifier for the user.
    /// </summary>
    [ForeignKey("UserRole")]
    public int RoleId { get; set; }

    /// <summary>
    /// Gets or sets the user role associated with the user.
    /// </summary>
    public UserRole? UserRole { get; set; }
}
