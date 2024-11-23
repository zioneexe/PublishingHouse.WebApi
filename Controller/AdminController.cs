using Microsoft.AspNetCore.Mvc;
using PublishingHouse.Abstractions.Service;
using PublishingHouse.DAL.Mapper;
using PublishingHouse.WebApi.Dto;
using PublishingHouse.WebApi.Mapper;

namespace PublishingHouse.WebApi.Controller;

[ApiController]
[Route("api/admins")]
public class AdminController(IAdminService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var admins = await service.GetAllAsync();

        return Ok(admins);
    }

    [HttpGet("{id:int:min(1)}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var admin = await service.GetByIdAsync(id);
        if (admin == null)
        {
            return NotFound();
        }
        return Ok(admin);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAdminDto adminDto)
    {
        var adminInput = adminDto.ToInputModel(); 
        var admin = await service.AddAsync(adminInput);

        return CreatedAtAction(nameof(GetById), new { id = admin.AdminId }, admin);
    }

    [HttpPut("{id:int:min(1)}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateAdminDto adminDto)
    {
        var existingAdmin = await service.GetByIdAsync(id);
        if (existingAdmin == null)
        {
            return NotFound($"Admin with ID {id} not found.");
        }

        var adminInput = adminDto.ToInputModel();
        var admin = await service.UpdateAsync(id, adminInput);

        if (admin == null)
        {
            return BadRequest("Update operation failed.");
        }

        return Ok(admin);
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
