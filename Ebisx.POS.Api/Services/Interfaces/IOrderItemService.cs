using Ebisx.POS.Api.Entities;

namespace Ebisx.POS.Api.Services.Interfaces
{
    public interface IOrderItemService
    {
        Task<IEnumerable<OrderItem>> GetAllOrderItemsAsync();
        Task<OrderItem?> GetOrderItemByIdAsync(int id);
        Task<OrderItem> CreateOrderItemAsync(OrderItem orderItem);
        Task<bool> UpdateOrderItemAsync(int id, OrderItem orderItem);
        Task<bool> DeleteOrderItemAsync(int id);
    }

}
