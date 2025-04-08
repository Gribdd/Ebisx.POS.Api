

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Ebisx.POS.Api.Entities;

public class OrderItem 
{
    [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int QuantityAtPurchase { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal PriceAtPurchase { get; set; } // Store price at the time of purchase

    [Column(TypeName = "decimal(18,2)")]
    public decimal VatAtPurchase { get; set; }
    
    [ForeignKey("Product")]
    public Guid ProductId { get; set; } // Reference to Product
    [JsonIgnore]
    public Product? Product { get; set; }

    [ForeignKey("Order")]
    public int OrderId { get; set; }
    public bool IsVoided { get; set; } = false;
}
