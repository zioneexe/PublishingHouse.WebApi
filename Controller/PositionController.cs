using Microsoft.AspNetCore.Mvc;
using PublishingHouse.Abstractions.Model;
using PublishingHouse.Abstractions.Service;
using PublishingHouse.DAL.Mapper;
using PublishingHouse.WebApi.Dto;
using PublishingHouse.WebApi.Mapper;

namespace PublishingHouse.WebApi.Controller;

[ApiController]
[Route("api/positions")]
public class PositionController(IPositionService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var positions = await service.GetAllAsync();

        return Ok(positions);
    }

    [HttpGet("{id:int:min(1)}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var position = await service.GetByIdAsync(id);
        if (position == null)
        {
            return NotFound();
        }
        return Ok(position);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePositionDto positionDto)
    {
        var positionInput = positionDto.ToInputModel();
        var position = await service.AddAsync(positionInput);

        return CreatedAtAction(nameof(GetById), new { id = position.PositionId }, position);
    }

    [HttpPut("{id:int:min(1)}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdatePositionDto positionDto)
    {
        var existingPosition = await service.GetByIdAsync(id);
        if (existingPosition == null)
        {
            return NotFound($"Position with ID {id} not found.");
        }

        var positionInput = positionDto.ToInputModel();
        var position = await service.UpdateAsync(id, positionInput);

        if (position == null)
        {
            return BadRequest("Update operation failed.");
        }

        return Ok(position);
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

    [HttpGet("{id:int:min(1)}/employees")]
    public async Task<IActionResult> GetPositionWithEmployees([FromRoute] int id)
    {
        var position = await service.GetPositionWithEmployeesAsync(id);
        if (position == null)
        {
            return NotFound();
        }
        return Ok(position);
    }
}
