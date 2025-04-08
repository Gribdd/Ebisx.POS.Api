using Ebisx.POS.Api.DTOs.Product;

namespace Ebisx.POS.Api.DTOs.OrderItem;

public class OrderItemResponseDto
{
    public int Id { get; set; }
    public int QuantityAtPurchase { get; set; }
    public decimal PriceAtPurchase { get; set; }
    public decimal VatAtPurchase { get; set; }
    public int ProductId { get; set; }
    public int OrderId { get; set; }
    public bool IsVoided { get; set; } = false;
}
