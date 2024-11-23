using Microsoft.AspNetCore.Mvc;
using PublishingHouse.Abstractions.Service;
using PublishingHouse.DAL.Mapper;
using PublishingHouse.WebApi.Dto;
using PublishingHouse.WebApi.Mapper;

namespace PublishingHouse.WebApi.Controller;

[ApiController]
[Route("api/regions")]
public class RegionController(IRegionService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var regions = await service.GetAllAsync();

        return Ok(regions);
    }

    [HttpGet("{id:int:min(1)}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var region = await service.GetByIdAsync(id);
        if (region == null)
        {
            return NotFound();
        }
        return Ok(region);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateRegionDto regionDto)
    {
        var regionInput = regionDto.ToInputModel();
        var region = await service.AddAsync(regionInput);

        return CreatedAtAction(nameof(GetById), new { id = region.RegionId }, region);
    }

    [HttpPut("{id:int:min(1)}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateRegionDto regionDto)
    {
        var existingRegion = await service.GetByIdAsync(id);
        if (existingRegion == null)
        {
            return NotFound($"Region with ID {id} not found.");
        }

        var regionInput = regionDto.ToInputModel();
        var region = await service.UpdateAsync(id, regionInput);

        if (region == null)
        {
            return BadRequest("Update operation failed.");
        }

        return Ok(region);
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

    [HttpGet("{id:int:min(1)}/cities")]
    public async Task<IActionResult> GetRegionWithCities([FromRoute] int id)
    {
        var region = await service.GetRegionWithCitiesAsync(id);
        if (region == null)
        {
            return NotFound();
        }
        return Ok(region);
    }
}
