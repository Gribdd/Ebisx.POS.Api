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
    public async Task<ActionResult<IEnumerable<OrderItemResponseDto>>> GetAll()
    {
        var orderItems = await _orderItemService.GetAllOrderItemsAsync();
        return Ok(orderItems);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<OrderItemResponseDto>> GetById(int id)
    {
        var orderItem = await _orderItemService.GetOrderItemByIdAsync(id);
        if (orderItem == null)
            return NotFound();

        return Ok(orderItem);
    }

    [HttpPost]
    public async Task<ActionResult<OrderItemResponseDto>> Create([FromBody] OrderItemRequestDto orderItem)
    {
        var createdOrderItem = await _orderItemService.CreateOrderItemAsync(orderItem);
        return CreatedAtAction(nameof(GetById), new { id = createdOrderItem.Id }, createdOrderItem);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] OrderItemRequestDto orderItem)
    {
        var updated = await _orderItemService.UpdateOrderItemAsync(id, orderItem);
        if (!updated)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _orderItemService.DeleteOrderItemAsync(id);
        if (!deleted)
            return NotFound();

        return NoContent();
    }
}
