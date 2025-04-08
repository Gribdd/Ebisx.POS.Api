using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ebisx.POS.Api.Entities;

/// <summary>
/// Represents a customer entity in the POS system.
/// </summary>
public class Customer
{
    /// <summary>
    /// Gets or sets the unique identifier for the customer.
    /// </summary>
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the customer.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets the address of the customer.
    /// </summary>
    public string? Address { get; set; }

    /// <summary>
    /// Gets or sets the Tax Identification Number (TIN) of the customer.
    /// </summary>
    public string? TinNumber { get; set; }

    /// <summary>
    /// Gets or sets the ID number for PWD or senior citizen discount.
    /// </summary>
    public string? IdNumber { get; set; }
}
