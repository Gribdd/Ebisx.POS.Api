

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ebisx.POS.Api.Entities;

public class OrderItem 
{
    public int Id { get; set; }

    public int QuantityAtPurchase { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal PriceAtPurchase { get; set; } // Store price at the time of purchase

    [Column(TypeName = "decimal(18,2)")]
    public decimal VatAtPurchase { get; set; }
    

    [ForeignKey("Product")]
    public Guid ProductId { get; set; } // Reference to Product

    [ForeignKey("Order")]
    public int OrderId { get; set; }

    [ForeignKey("Discount")]
    public int DiscountId { get; set; }
}
