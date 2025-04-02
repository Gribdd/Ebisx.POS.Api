

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ebisx.POS.Api.Entities;

public class OrderItem : IBaseEntity
{

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public Guid Id { get; set; }

    public int QuantityAtPurchase { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal PriceAtPurchase { get; set; } // Store price at the time of purchase

    [Column(TypeName = "decimal(18,2)")]
    public decimal VatAtPurchase { get; set; }
    

    [ForeignKey("Product")]
    public Guid ProductId { get; set; } // Reference to Product
    public Product? Product { get; set; }

    [ForeignKey("Order")]
    public Guid OrderId { get; set; }
    public Order? Order { get; set; }
}
