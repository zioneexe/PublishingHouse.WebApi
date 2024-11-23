using Microsoft.AspNetCore.Mvc;
using PublishingHouse.Abstractions.Model;
using PublishingHouse.Abstractions.Service;
using PublishingHouse.DAL.Mapper;
using PublishingHouse.WebApi.Dto;
using PublishingHouse.WebApi.Mapper;

namespace PublishingHouse.WebApi.Controller;

[ApiController]
[Route("api/batches")]
public class BatchPrintController(IBatchPrintService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var batchPrints = await service.GetAllAsync();

        return Ok(batchPrints);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var batchPrint = await service.GetByIdAsync(id);
        if (batchPrint == null)
        {
            return NotFound();
        }
        return Ok(batchPrint);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateBatchPrintDto batchPrintDto)
    {
        var batchPrintInput = batchPrintDto.ToInputModel();
        var batchPrint = await service.AddAsync(batchPrintInput);

        return CreatedAtAction(nameof(GetById), new { id = batchPrint.BatchPrintId }, batchPrint);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateBatchPrintDto batchPrintDto)
    {
        var existingBatchPrint = await service.GetByIdAsync(id);
        if (existingBatchPrint == null)
        {
            return NotFound($"Batch print with ID {id} not found.");
        }

        var batchPrintInput = batchPrintDto.ToInputModel();
        var batchPrint = await service.UpdateAsync(id, batchPrintInput);

        if (batchPrint == null)
        {
            return BadRequest("Update operation failed.");
        }

        return Ok(batchPrint);
    }

    [HttpDelete("{id:int}")]
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
