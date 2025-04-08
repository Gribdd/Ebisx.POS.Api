using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ebisx.POS.Api.Entities;

/// <summary>
/// Represents the business information entity.
/// </summary>
public class BusinessInfo
{
    /// <summary>
    /// Gets or sets the unique identifier for the business.
    /// </summary>
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the registered name of the business.
    /// </summary>
    [Required]
    public string RegistedName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the address of the business.
    /// </summary>
    [Required]
    public string Address { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the VAT/TIN number of the business.
    /// </summary>
    [Required]
    public string VatTinNumber { get; set; } = string.Empty;
}
