using Ebisx.POS.Api.DTOs.OrderItem;

namespace Ebisx.POS.Api.DTOs.Order;

public class OrderResponseDto
{
    public int Id { get; set; }
    public ICollection<OrderItemResponseDto> OrderItems { get; set; } = new List<OrderItemResponseDto>();
    public string Status { get; set; } = string.Empty;
}
