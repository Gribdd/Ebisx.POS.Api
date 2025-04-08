using Ebisx.POS.Api.DTOs.Order;
using Ebisx.POS.Api.DTOs.OrderItem;
using Ebisx.POS.Api.Entities;
using Ebisx.POS.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ebisx.POS.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderItemController : Controller
{
    private readonly IOrderItemService _orderItemService;

    public OrderItemController(IOrderItemService orderItemService)
    {
        _orderItemService = orderItemService;
    }

    [HttpGet]
    [ProducesResponseType(type: typeof(IEnumerable<OrderItemResponseDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var orderItems = await _orderItemService.GetAllOrderItemsAsync();
        return Ok(orderItems);
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(type: typeof(OrderItemResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int id)
    {
        var orderItem = await _orderItemService.GetOrderItemByIdAsync(id);
        if (orderItem == null)
        {
            return NotFound();
        }
        return Ok(orderItem);
    }

    [HttpPost]
    [ProducesResponseType(type: typeof(OrderItemResponseDto), StatusCodes.Status201Created)]
    public async Task<IActionResult> Create([FromBody] OrderItemRequestDto orderItem)
    {
        var createdOrderItem = await _orderItemService.CreateOrderItemAsync(orderItem);
        return CreatedAtAction(nameof(GetById), new { id = createdOrderItem.Id }, createdOrderItem);
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(int id, [FromBody] OrderItemRequestDto orderItem)
    {
        var updated = await _orderItemService.UpdateOrderItemAsync(id, orderItem);
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
        var deleted = await _orderItemService.DeleteOrderItemAsync(id);
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }
}
