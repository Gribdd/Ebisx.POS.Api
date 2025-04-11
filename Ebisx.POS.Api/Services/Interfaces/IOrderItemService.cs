using Ebisx.POS.Api.DTOs.OrderItem;
using Ebisx.POS.Api.Entities;

namespace Ebisx.POS.Api.Services.Interfaces;

public interface IOrderItemService
{
    Task<IEnumerable<OrderItemResponseDto>> GetAllOrderItemsAsync();
    Task<OrderItemResponseDto?> GetOrderItemByIdAsync(int id);
    Task<OrderItemResponseDto> CreateOrderItemAsync(OrderItemRequestDto orderItem);
    Task<bool> UpdateOrderItemAsync(int id, OrderItemRequestDto orderItem);
    Task<bool> DeleteOrderItemAsync(int id);
}
