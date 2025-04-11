using Ebisx.POS.Api.DTOs;
using Ebisx.POS.Api.DTOs.Order;
using Ebisx.POS.Api.DTOs.OrderItem;
using Ebisx.POS.Api.Entities;
using Ebisx.POS.Api.Services;
using Ebisx.POS.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ebisx.POS.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    [ProducesResponseType(type: typeof(IEnumerable<OrderResponseDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var orders = await _orderService.GetAllOrdersAsync();
        return Ok(orders);
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(type: typeof(OrderResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int id)
    {
        var order = await _orderService.GetOrderByIdAsync(id);
        if (order == null)
        {
            return NotFound();
        }
        return Ok(order);
    }

    [HttpPost]
    [ProducesResponseType(type: typeof(OrderResponseDto), StatusCodes.Status201Created)]
    public async Task<IActionResult> Create([FromBody] OrderRequestDto order)
    {
        var createdOrder = await _orderService.CreateOrderAsync(order);
        return CreatedAtAction(nameof(GetById), new { id = createdOrder.Id }, createdOrder);
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(int id, [FromBody] OrderRequestDto order)
    {
        var updated = await _orderService.UpdateOrderAsync(id, order);
        if (!updated)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _orderService.DeleteOrderAsync(id);
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpPost("{orderId:int}/items")]
    [ProducesResponseType(type:typeof(OrderResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AddOrderItems(int orderId, [FromBody] List<OrderItemRequestDto> orderItemsRequest)
    {
        await _orderService.AddOrderItemsToExistingOrderAsync(orderId, orderItemsRequest);

        var updatedOrder = await _orderService.GetOrderByIdAsync(orderId);

        if (updatedOrder == null)
        {
            return NotFound(); 
        }

        return Ok(updatedOrder);
    }
}