using Ebisx.POS.Api.DTOs;
using Ebisx.POS.Api.DTOs.Order;
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
    public async Task<ActionResult<IEnumerable<OrderResponseDto>>> GetAll()
    {
        var orders = await _orderService.GetAllOrdersAsync();
        return Ok(orders);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<OrderResponseDto>> GetById(int id)
    {
        var order = await _orderService.GetOrderByIdAsync(id);
        if (order == null)
            return NotFound();

        return Ok(order);
    }

    [HttpPost]  
    public async Task<ActionResult<OrderResponseDto>> Create([FromBody] OrderRequestDto order)
    {
        var createdOrder = await _orderService.CreateOrderAsync(order);
        return CreatedAtAction(nameof(GetById), new { id = createdOrder.Id }, createdOrder);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] OrderRequestDto order)
    {
        var updated = await _orderService.UpdateOrderAsync(id, order);
        if (!updated)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {   
        var deleted = await _orderService.DeleteOrderAsync(id);
        if (!deleted)
            return NotFound();

        return NoContent();
    }
}