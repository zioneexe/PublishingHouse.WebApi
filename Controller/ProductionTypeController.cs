using Microsoft.AspNetCore.Mvc;
using PublishingHouse.Abstractions.Service;
using PublishingHouse.DAL.Mapper;
using PublishingHouse.WebApi.Dto;
using PublishingHouse.WebApi.Mapper;

namespace PublishingHouse.WebApi.Controller;

[ApiController]
[Route("api/productiontypes")]
public class ProductionTypeController(IProductionTypeService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var productionTypes = await service.GetAllAsync();

        return Ok(productionTypes);
    }

    [HttpGet("{id:int:min(1)}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var productionType = await service.GetByIdAsync(id);
        if (productionType == null)
        {
            return NotFound();
        }
        return Ok(productionType);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductionTypeDto productionTypeDto)
    {
        var productionTypeInput = productionTypeDto.ToInputModel();
        var productionType = await service.AddAsync(productionTypeInput);

        return CreatedAtAction(nameof(GetById), new { id = productionType.ProductionTypeId }, productionType);
    }

    [HttpPut("{id:int:min(1)}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateProductionTypeDto productionTypeDto)
    {
        var existingProductionType = await service.GetByIdAsync(id);
        if (existingProductionType == null)
        {
            return NotFound($"Production type with ID {id} not found.");
        }

        var productionTypeInput = productionTypeDto.ToInputModel();
        var productionType = await service.UpdateAsync(id, productionTypeInput);

        if (productionType == null)
        {
            return BadRequest("Update operation failed.");
        }

        return Ok(productionType);
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

    [HttpGet("{id:int:min(1)}/productions")]
    public async Task<IActionResult> GetProductionTypeWithProductions([FromRoute] int id)
    {
        var productionType = await service.GetProductionTypeWithProductionsAsync(id);
        if (productionType == null)
        {
            return NotFound();
        }
        return Ok(productionType);
    }
}
