using Ebisx.POS.Api.Entities;

namespace Ebisx.POS.Api.Services.Interfaces
{
    public interface IOrderItemService
    {
        Task<IEnumerable<OrderItem>> GetAllOrderItemsAsync();
        Task<OrderItem?> GetOrderItemByIdAsync(Guid id);
        Task<OrderItem> CreateOrderItemAsync(OrderItem orderItem);
        Task<bool> UpdateOrderItemAsync(Guid id, OrderItem orderItem);
        Task<bool> DeleteOrderItemAsync(Guid id);
    }

}
