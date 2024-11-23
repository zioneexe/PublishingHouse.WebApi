using Microsoft.AspNetCore.Mvc;
using PublishingHouse.Abstractions.Model;
using PublishingHouse.Abstractions.Service;
using PublishingHouse.DAL.Mapper;
using PublishingHouse.WebApi.Dto;
using PublishingHouse.WebApi.Mapper;

namespace PublishingHouse.WebApi.Controller;

[ApiController]
[Route("api/qualitymarks")]
public class QualityMarkController(IQualityMarkService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var qualityMarks = await service.GetAllAsync();

        return Ok(qualityMarks);
    }

    [HttpGet("{id:int:min(1)}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var qualityMark = await service.GetByIdAsync(id);
        if (qualityMark == null)
        {
            return NotFound();
        }
        return Ok(qualityMark);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateQualityMarkDto qualityMarkDto)
    {
        var qualityMarkInput = qualityMarkDto.ToInputModel();
        var qualityMark = await service.AddAsync(qualityMarkInput);

        return CreatedAtAction(nameof(GetById), new { id = qualityMark.QualityMarkId }, qualityMark);
    }

    [HttpPut("{id:int:min(1)}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateQualityMarkDto qualityMarkDto)
    {
        var existingQualityMark = await service.GetByIdAsync(id);
        if (existingQualityMark == null)
        {
            return NotFound($"Quality mark with ID {id} not found.");
        }

        var qualityMarkInput = qualityMarkDto.ToInputModel();
        var qualityMark = await service.UpdateAsync(id, qualityMarkInput);

        if (qualityMark == null)
        {
            return BadRequest("Update operation failed.");
        }

        return Ok(qualityMark);
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

    [HttpGet("{id:int:min(1)}/batchprints")]
    public async Task<IActionResult> GetQualityMarkWithBatchPrints([FromRoute] int id)
    {
        var qualityMark = await service.GetQualityMarkWithBatchPrintsAsync(id);
        if (qualityMark == null)
        {
            return NotFound();
        }
        return Ok(qualityMark);
    }
}
