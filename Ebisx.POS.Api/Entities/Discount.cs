using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ebisx.POS.Api.Entities;

/// <summary>
/// Represents a discount entity.
/// </summary>
public class Discount
{
    /// <summary>
    /// Gets or sets the unique identifier for the discount.
    /// </summary>
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the value of the discount.
    /// </summary>
    [Required]
    public string Value { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets a value indicating whether the discount is a percentage.
    /// </summary>
    [Required]
    public bool IsPercentage { get; set; }

    /// <summary>
    /// Gets or sets the foreign key for the discount type.
    /// </summary>
    [Required]
    [ForeignKey("DiscountType")]
    public int DiscountTypeId { get; set; }

    /// <summary>
    /// Gets or sets the discount type associated with this discount.
    /// </summary>
    public DiscountType? DiscountType { get; set; }
}
