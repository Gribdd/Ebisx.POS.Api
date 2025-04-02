using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ebisx.POS.Api.Entities;

public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PrivateId { get; set; }
    [MaxLength(20)]
    public string PublicId { get; set; } = string.Empty;
    [Required]
    public string FName { get; set; } = string.Empty;
    [Required] 
    public string LName { get; set; } = string.Empty;
    [Required]
    public string EmailAddress { get; set; } = string.Empty;
    public string? Address { get; set; }
    public DateTime BirthDate { get; set; }
    [Required] 
    public string Username{ get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;


    [ForeignKey("UserRole")]
    public int RoleId { get; set; }
    public UserRole? UserRole { get; set; }
}
