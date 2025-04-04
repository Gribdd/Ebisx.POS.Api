using Ebisx.POS.Api.Data;
using Ebisx.POS.Api.Entities;
using Ebisx.POS.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ebisx.POS.Api.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IOrderItemService _orderItemService;

        public OrderService(
            ApplicationDbContext dbContext,
            IOrderItemService orderItemService)
        {
            _dbContext = dbContext;
            _orderItemService = orderItemService;
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _dbContext.Orders
                .Include(o => o.OrderItems)
                .ToListAsync();
        }

        public async Task<Order?> GetOrderByIdAsync(int id)
        {
            return await _dbContext.Orders
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<Order> CreateOrderAsync(Order order)
        {

            _dbContext.Orders.Add(order);
            await _dbContext.SaveChangesAsync();

            if(order.OrderItems != null && order.OrderItems.Any())
            {
                foreach (var item in order.OrderItems)
                {
                    item.OrderId = order.Id;             
                    await _orderItemService.CreateOrderItemAsync(item); // ✅ Use service
                }
            }
            return order;
        }

        public async Task<bool> DeleteOrderAsync(int id)
        {
            var order = await _dbContext.Orders
                .Include(o => o.OrderItems) // Ensure OrderItems are loaded
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null) return false;

            // Use the OrderItemService to delete all related OrderItems
            foreach (var orderItem in order.OrderItems)
            {
                // Assuming DeleteOrderItemAsync takes care of removing an order item
                var result = await _orderItemService.DeleteOrderItemAsync(orderItem.Id);
                if (!result)
                {
                    return false; // If any deletion fails, return false
                }
            }


            // Now delete the Order
            _dbContext.Orders.Remove(order);

            await _dbContext.SaveChangesAsync();
            return true;
        }

        public Task<bool> UpdateOrderAsync(int id, Order order)
        {
            throw new NotImplementedException();
        }
    }
}
