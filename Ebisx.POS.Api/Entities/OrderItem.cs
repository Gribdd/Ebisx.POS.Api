

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Ebisx.POS.Api.Entities;

/// <summary>
/// Represents an item in an order, including details such as quantity, price, VAT, and product reference.
/// </summary>
public class OrderItem
{
    /// <summary>
    /// Gets or sets the unique identifier for the order item.
    /// </summary>
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the quantity of the product at the time of purchase.
    /// </summary>
    public int QuantityAtPurchase { get; set; }

    /// <summary>
    /// Gets or sets the price of the product at the time of purchase.
    /// </summary>
    [Column(TypeName = "decimal(18,2)")]
    public decimal PriceAtPurchase { get; set; }

    /// <summary>
    /// Gets or sets the VAT (Value Added Tax) of the product at the time of purchase.
    /// </summary>
    [Column(TypeName = "decimal(18,2)")]
    public decimal VatAtPurchase { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the associated product.
    /// </summary>
    [ForeignKey("Product")]
    public int ProductId { get; set; }

    /// <summary>
    /// Gets or sets the associated product entity. This property is ignored during JSON serialization.
    /// </summary>
    public Product Product { get; set; } = null!;

    /// <summary>
    /// Gets or sets the unique identifier of the associated order.
    /// </summary>
    [ForeignKey("Order")]
    public int OrderId { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the order item is voided.
    /// </summary>
    public bool IsVoided { get; set; } = false;
}
