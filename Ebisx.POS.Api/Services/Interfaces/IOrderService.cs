using Ebisx.POS.Api.DTOs.Order;
using Ebisx.POS.Api.DTOs.OrderItem;

namespace Ebisx.POS.Api.Services.Interfaces;

public interface IOrderService
{
    Task<IEnumerable<OrderResponseDto>> GetAllOrdersAsync();
    Task<OrderResponseDto?> GetOrderByIdAsync(int id);
    Task<OrderResponseDto> CreateOrderAsync(OrderRequestDto order);
    Task AddOrderItemsToExistingOrderAsync(int orderId, List<OrderItemRequestDto> orderItemsRequest);
    Task<bool> UpdateOrderAsync(int id, OrderRequestDto order);
    Task<bool> DeleteOrderAsync(int id);
}
