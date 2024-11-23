using Microsoft.AspNetCore.Mvc;
using PublishingHouse.Abstractions.Model;
using PublishingHouse.Abstractions.Service;
using PublishingHouse.DAL.Mapper;
using PublishingHouse.WebApi.Dto;
using PublishingHouse.WebApi.Mapper;

namespace PublishingHouse.WebApi.Controller;

[ApiController]
[Route("api/cities")]
public class CityController(ICityService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var cities = await service.GetAllAsync();

        return Ok(cities);
    }

    [HttpGet("{id:int:min(1)}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var city = await service.GetByIdAsync(id);
        if (city == null)
        {
            return NotFound();
        }
        return Ok(city);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCityDto cityDto)
    {
        var cityInput = cityDto.ToInputModel();
        var city = await service.AddAsync(cityInput);

        return CreatedAtAction(nameof(GetById), new { id = city.CityId }, city);
    }

    [HttpPut("{id:int:min(1)}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCityDto cityDto)
    {
        var existingCity = await service.GetByIdAsync(id);
        if (existingCity == null)
        {
            return NotFound($"City with ID {id} not found.");
        }

        var cityInput = cityDto.ToInputModel();
        var city = await service.UpdateAsync(id,cityInput);

        if (city == null)
        {
            return BadRequest("Update operation failed.");
        }

        return Ok(city);
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
