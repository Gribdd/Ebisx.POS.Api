using AutoMapper;
using Ebisx.POS.Api.Data;
using Ebisx.POS.Api.DTOs.Order;
using Ebisx.POS.Api.DTOs.OrderItem;
using Ebisx.POS.Api.Entities;
using Ebisx.POS.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ebisx.POS.Api.Services;

/// <summary>
/// Service for managing orders in the POS system.
/// </summary>
public class OrderService : IOrderService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="OrderService"/> class.
    /// </summary>
    /// <param name="dbContext">The database context for accessing order data.</param>
    /// <param name="mapper">The mapper for converting between entities and DTOs.</param>
    public OrderService(
        ApplicationDbContext dbContext,
        IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    /// <summary>
    /// Retrieves all orders from the database.
    /// </summary>
    /// <returns>A collection of <see cref="OrderResponseDto"/> representing all orders.</returns>
    public async Task<IEnumerable<OrderResponseDto>> GetAllOrdersAsync()
    {
        try
        {
            var orders = await _dbContext.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .ToListAsync();

            var orderDtos = _mapper.Map<IEnumerable<OrderResponseDto>>(orders);
            return orderDtos;
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Retrieves a specific order by its ID.
    /// </summary>
    /// <param name="id">The ID of the order to retrieve.</param>
    /// <returns>An <see cref="OrderResponseDto"/> representing the order, or null if not found.</returns>
    public async Task<OrderResponseDto?> GetOrderByIdAsync(int id)
    {
        try
        {
            var order = await _dbContext.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(o => o.Id == id);
            if (order == null) return null;
            var orderDto = _mapper.Map<OrderResponseDto>(order);
            return orderDto;
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Creates a new order in the database.
    /// </summary>
    /// <param name="order">The <see cref="OrderRequestDto"/> containing order details.</param>
    /// <returns>The created <see cref="OrderResponseDto"/>.</returns>
    public async Task<OrderResponseDto> CreateOrderAsync(OrderRequestDto order)
    {
        try
        {
            var orderEntity = _mapper.Map<Order>(order);
            _dbContext.Orders.Add(orderEntity);
            await _dbContext.SaveChangesAsync();

            var createdOrder = await _dbContext.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(o => o.Id == orderEntity.Id);

            return _mapper.Map<OrderResponseDto>(orderEntity);
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    /// <summary>
    /// Updates an existing order in the database.
    /// </summary>
    /// <param name="id">The ID of the order to update.</param>
    /// <param name="updatedOrderDto">The updated order details.</param>
    /// <returns>True if the update was successful, false if the order was not found.</returns>
    public async Task<bool> UpdateOrderAsync(int id, OrderRequestDto updatedOrderDto)
    {
        try
        {
            var existingOrder = await _dbContext.Orders
                .Include(o => o.OrderItems)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (existingOrder == null)
                return false;

            var existingEntry = _dbContext.Entry(existingOrder);
            existingEntry.CurrentValues.SetValues(updatedOrderDto);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Deletes an order from the database.
    /// </summary>
    /// <param name="id">The ID of the order to delete.</param>
    /// <returns>True if the deletion was successful, false if the order was not found.</returns>
    public async Task<bool> DeleteOrderAsync(int id)
    {
        try
        {
            var order = await _dbContext.Orders
            .Include(o => o.OrderItems) // Ensure OrderItems are loaded
            .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null) return false;

            _dbContext.Orders.Remove(order);

            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch
        {
            throw;
        }
    }

    public async Task AddOrderItemsToExistingOrderAsync(int orderId, List<OrderItemRequestDto> orderItemsRequest)
    {
        // Fetch the order to add items to
        var order = await _dbContext.Orders
                                  .Include(o => o.OrderItems)
                                  .FirstOrDefaultAsync(o => o.Id == orderId);

        if (order != null)
        {
            var existingProductIds = order.OrderItems.Select(i => i.ProductId).ToHashSet();

            foreach (var orderItem in orderItemsRequest)
            {
                if (!existingProductIds.Contains(orderItem.ProductId))
                {
                    order.OrderItems.Add(_mapper.Map<OrderItem>(orderItem));
                }
            }

            // Save changes to the database
            await _dbContext.SaveChangesAsync();
        }
        else
        {
            throw new InvalidOperationException("Order not found.");
        }
    }
}
