using Ebisx.POS.Api.Data;
using Ebisx.POS.Api.Entities;
using Ebisx.POS.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ebisx.POS.Api.Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly ApplicationDbContext _dbContext;

        public OrderItemService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<OrderItem>> GetAllOrderItemsAsync()
        {
            return await _dbContext.OrderItems.ToListAsync();
        }

        public async Task<OrderItem?> GetOrderItemByIdAsync(int id)
        {
            return await _dbContext.OrderItems.FindAsync(id);
        }

        public async Task<OrderItem> CreateOrderItemAsync(OrderItem orderItem)
        {
            _dbContext.OrderItems.Add(orderItem);
            await _dbContext.SaveChangesAsync();
            return orderItem;
        }

        public async Task<bool> UpdateOrderItemAsync(int id, OrderItem updatedOrderItem)
        {
            var existingOrderItem = await _dbContext.OrderItems.FindAsync(id);
            if (existingOrderItem == null) return false;

            existingOrderItem.QuantityAtPurchase = updatedOrderItem.QuantityAtPurchase;
            existingOrderItem.PriceAtPurchase = updatedOrderItem.PriceAtPurchase;
            existingOrderItem.VatAtPurchase = updatedOrderItem.VatAtPurchase;
            existingOrderItem.ProductId = updatedOrderItem.ProductId;
            existingOrderItem.OrderId = updatedOrderItem.OrderId;

            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteOrderItemAsync(int id)
        {
            var orderItem = await _dbContext.OrderItems.FindAsync(id);
            if (orderItem == null) return false;

            _dbContext.OrderItems.Remove(orderItem);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
