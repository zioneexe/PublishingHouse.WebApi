using Microsoft.AspNetCore.Mvc;
using PublishingHouse.Abstractions.Model;
using PublishingHouse.Abstractions.Service;
using PublishingHouse.DAL.Mapper;
using PublishingHouse.WebApi.Dto;
using PublishingHouse.WebApi.Mapper;

namespace PublishingHouse.WebApi.Controller;

[ApiController]
[Route("api/orderbooks")]
public class OrderBookController(IOrderBookService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var orderBooks = await service.GetAllAsync();

        return Ok(orderBooks);
    }
    
    [HttpGet("{id:int:min(1)}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var orderBook = await service.GetByIdAsync(id);
        if (orderBook == null)
        {
            return NotFound();
        }
        return Ok(orderBook);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateOrderBookDto orderBookDto)
    {
        var orderBookInput = orderBookDto.ToInputModel();
        var orderBook = await service.AddAsync(orderBookInput);

        return CreatedAtAction(nameof(GetById), new { id = orderBook.OrderBooksId }, orderBook);
    }

    [HttpPut("{id:int:min(1)}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateOrderBookDto orderBookDto)
    {
        var existingOrderBook = await service.GetByIdAsync(id);
        if (existingOrderBook == null)
        {
            return NotFound($"Order for book with ID {id} not found.");
        }

        var orderBookInput = orderBookDto.ToInputModel();
        var orderBook = await service.UpdateAsync(id, orderBookInput);

        if (orderBook == null)
        {
            return BadRequest("Update operation failed.");
        }

        return Ok(orderBook);
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
