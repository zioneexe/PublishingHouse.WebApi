using Microsoft.AspNetCore.Mvc;
using PublishingHouse.Abstractions.Model;
using PublishingHouse.Abstractions.Service;
using PublishingHouse.DAL.Mapper;
using PublishingHouse.WebApi.Dto;
using PublishingHouse.WebApi.Mapper;

namespace PublishingHouse.WebApi.Controller;

[ApiController]
[Route("api/orderstatuses")]
public class OrderStatusController(IOrderStatusService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var orderStatuses = await service.GetAllAsync();

        return Ok(orderStatuses);
    }

    [HttpGet("{id:int:min(1)}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var orderStatus = await service.GetByIdAsync(id);
        if (orderStatus == null)
        {
            return NotFound();
        }
        return Ok(orderStatus);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateOrderStatusDto orderStatusDto)
    {
        var orderStatusInput = orderStatusDto.ToInputModel();
        var orderStatus = await service.AddAsync(orderStatusInput);

        return CreatedAtAction(nameof(GetById), new { id = orderStatus.OrderStatusId }, orderStatus);
    }

    [HttpPut("{id:int:min(1)}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateOrderStatusDto orderStatusDto)
    {
        var existingOrderStatus = await service.GetByIdAsync(id);
        if (existingOrderStatus == null)
        {
            return NotFound($"Order status with ID {id} not found.");
        }

        var orderStatusInput = orderStatusDto.ToInputModel();
        var orderStatus = await service.UpdateAsync(id, orderStatusInput);

        if (orderStatus == null)
        {
            return BadRequest("Update operation failed.");
        }

        return Ok(orderStatus);
    }

    [HttpDelete("{id:int:min(1)}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var exists = await service.GetByIdAsync(id);
        if (exists == null)
        {
            return NotFound();
        }

        await service.DeleteAsync(id);
        return NoContent();
    }
}
