using Microsoft.AspNetCore.Mvc;
using PublishingHouse.Abstractions.Model;
using PublishingHouse.Abstractions.Service;
using PublishingHouse.DAL.Mapper;
using PublishingHouse.WebApi.Dto;
using PublishingHouse.WebApi.Mapper;

namespace PublishingHouse.WebApi.Controller;

[ApiController]
[Route("api/productions")]
public class ProductionController(IProductionService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var productions = await service.GetAllAsync();

        return Ok(productions);
    }

    [HttpGet("{id:int:min(1)}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var production = await service.GetByIdAsync(id);
        if (production == null)
        {
            return NotFound();
        }
        return Ok(production);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductionDto productionDto)
    {
        var productionInput = productionDto.ToInputModel();
        var production = await service.AddAsync(productionInput);

        return CreatedAtAction(nameof(GetById), new { id = production.ProductionId }, production);
    }

    [HttpPut("{id:int:min(1)}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateProductionDto productionDto)
    {
        var existingProduction = await service.GetByIdAsync(id);
        if (existingProduction == null)
        {
            return NotFound($"Production with ID {id} not found.");
        }

        var productionInput = productionDto.ToInputModel();
        var production = await service.UpdateAsync(id, productionInput);

        if (production == null)
        {
            return BadRequest("Update operation failed.");
        }

        return Ok(production);
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
