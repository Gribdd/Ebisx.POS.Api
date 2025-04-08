using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ebisx.POS.Api.Entities;

/// <summary>
/// Represents a non-cash payment method entity.
/// </summary>
public class NonCashPaymentMethod
{
    /// <summary>
    /// Gets or sets the unique identifier for the non-cash payment method.
    /// </summary>
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the provider of the non-cash payment method.
    /// </summary>
    [Required]
    public string Provider { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the account number associated with the non-cash payment method.
    /// </summary>
    [Required]
    public string AccountNumber { get; set; } = string.Empty;
}
