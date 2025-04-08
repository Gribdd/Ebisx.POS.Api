using Ebisx.POS.Api.DTOs.Order;

namespace Ebisx.POS.Api.Services.Interfaces;

public interface IOrderService
{
    Task<IEnumerable<OrderResponseDto>> GetAllOrdersAsync();
    Task<OrderResponseDto?> GetOrderByIdAsync(int id);
    Task<OrderResponseDto> CreateOrderAsync(OrderRequestDto order);
    Task<bool> UpdateOrderAsync(int id, OrderRequestDto order);
    Task<bool> DeleteOrderAsync(int id);
}
