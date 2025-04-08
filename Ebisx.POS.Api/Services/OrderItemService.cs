using AutoMapper;
using Ebisx.POS.Api.Data;
using Ebisx.POS.Api.DTOs.OrderItem;
using Ebisx.POS.Api.Entities;
using Ebisx.POS.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ebisx.POS.Api.Services;

/// <summary>
/// Service for managing order items in the POS system.
/// </summary>
public class OrderItemService : IOrderItemService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="OrderItemService"/> class.
    /// </summary>
    /// <param name="dbContext">The database context for accessing order item data.</param>
    /// <param name="mapper">The AutoMapper instance for mapping entities to DTOs.</param>
    public OrderItemService(
        ApplicationDbContext dbContext,
        IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    /// <summary>
    /// Retrieves all order items from the database.
    /// </summary>
    /// <returns>A collection of <see cref="OrderItemResponseDto"/> representing all order items.</returns>
    public async Task<IEnumerable<OrderItemResponseDto>> GetAllOrderItemsAsync()
    {
        try
        {
            var orderItems = await _dbContext.OrderItems.ToListAsync();
            var orderItemsResponseDto = _mapper.Map<IEnumerable<OrderItemResponseDto>>(orderItems);
            return orderItemsResponseDto;
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Retrieves a specific order item by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the order item.</param>
    /// <returns>An <see cref="OrderItemResponseDto"/> if found; otherwise, null.</returns>
    public async Task<OrderItemResponseDto?> GetOrderItemByIdAsync(int id)
    {
        try
        {
            var orderItem = await _dbContext.OrderItems
                .FirstOrDefaultAsync(o => o.Id == id);

            if (orderItem == null) return null;
            var orderItemResponseDto = _mapper.Map<OrderItemResponseDto>(orderItem);
            return orderItemResponseDto;
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Creates a new order item in the database.
    /// </summary>
    /// <param name="orderItemRequestDto">The DTO containing the details of the order item to create.</param>
    /// <returns>The created <see cref="OrderItemResponseDto"/>.</returns>
    public async Task<OrderItemResponseDto> CreateOrderItemAsync(OrderItemRequestDto orderItemRequestDto)
    {
        try
        {
            var orderItemEntity = _mapper.Map<OrderItem>(orderItemRequestDto);
            _dbContext.OrderItems.Add(orderItemEntity);
            await _dbContext.SaveChangesAsync();

            var createdOrderItemResponseDto = _mapper.Map<OrderItemResponseDto>(orderItemEntity);
            return createdOrderItemResponseDto;
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Updates an existing order item in the database.
    /// </summary>
    /// <param name="id">The unique identifier of the order item to update.</param>
    /// <param name="updatedOrderItemDto">The DTO containing the updated details of the order item.</param>
    /// <returns>True if the update was successful; otherwise, false.</returns>
    public async Task<bool> UpdateOrderItemAsync(int id, OrderItemRequestDto updatedOrderItemDto)
    {
        try
        {
            var existingOrderItem = await _dbContext.OrderItems
                .FirstOrDefaultAsync(oi => oi.Id == id);

            if (existingOrderItem == null)
                return false;

            var existingEntry = _dbContext.Entry(existingOrderItem);
            existingEntry.CurrentValues.SetValues(updatedOrderItemDto);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Deletes an order item from the database.
    /// </summary>
    /// <param name="id">The unique identifier of the order item to delete.</param>
    /// <returns>True if the deletion was successful; otherwise, false.</returns>
    public async Task<bool> DeleteOrderItemAsync(int id)
    {
        try
        {
            var orderItem = await _dbContext.OrderItems
                .FirstOrDefaultAsync(o => o.Id == id);

            if (orderItem == null) return false;

            _dbContext.OrderItems.Remove(orderItem);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch
        {
            throw;
        }
    }
}
