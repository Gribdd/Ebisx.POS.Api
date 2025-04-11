
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Ebisx.POS.Api.Entities;

/// <summary>
/// Represents a product entity with properties such as Id, Name, Barcode, Quantity, Price, Vat, and SalesUnit.
/// </summary>
[Index(nameof(Barcode), IsUnique = true)]
public class Product
{
    /// <summary>
    /// Gets or sets the unique identifier for the product. 
    /// </summary>
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the product.
    /// </summary>
    [Required]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the barcode of the product.
    /// </summary>
    [Required]
    public string Barcode { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the quantity of the product in stock.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Gets or sets the price of the product.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Gets or sets the VAT (Value Added Tax) for the product.
    /// </summary>
    public decimal Vat { get; set; }

    /// <summary>
    /// Gets or sets the sales unit of the product.
    /// </summary>
    [Required]
    public string SalesUnit { get; set; } = string.Empty;
}
