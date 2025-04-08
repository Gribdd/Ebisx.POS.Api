using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ebisx.POS.Api.Entities;

/// <summary>
/// Represents a type of payment in the POS system.
/// </summary>
[Index(nameof(Name), IsUnique = true)]
public class PaymentType
{
    /// <summary>
    /// Gets or sets the unique identifier for the payment type.
    /// </summary>
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the payment type.
    /// </summary>
    [Required]
    public string Name { get; set; } = string.Empty;
}
