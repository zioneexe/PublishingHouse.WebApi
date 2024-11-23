using Microsoft.AspNetCore.Mvc;
using PublishingHouse.Abstractions.Service;
using PublishingHouse.DAL.Mapper;
using PublishingHouse.WebApi.Dto;
using PublishingHouse.WebApi.Mapper;

namespace PublishingHouse.WebApi.Controller;

[ApiController]
[Route("api/orders")]
public class PrintOrderController(IPrintOrderService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var printOrders = await service.GetAllAsync();

        return Ok(printOrders);
    }

    [HttpGet("{id:int:min(1)}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var printOrder = await service.GetByIdAsync(id);
        if (printOrder == null)
        {
            return NotFound();
        }
        return Ok(printOrder);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePrintOrderDto printOrderDto)
    {
        var printOrderInput = printOrderDto.ToInputModel();
        var printOrder = await service.AddAsync(printOrderInput);

        return CreatedAtAction(nameof(GetById), new { id = printOrder.OrderId }, printOrder);
    }

    [HttpPut("{id:int:min(1)}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdatePrintOrderDto printOrderDto)
    {
        var existingPrintOrder = await service.GetByIdAsync(id);
        if (existingPrintOrder == null)
        {
            return NotFound($"Order with ID {id} not found.");
        }

        var printOrderInput = printOrderDto.ToInputModel();
        var printOrder = await service.UpdateAsync(id, printOrderInput);

        if (printOrder == null)
        {
            return BadRequest("Update operation failed.");
        }

        return Ok(printOrder);
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
