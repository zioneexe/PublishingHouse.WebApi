using Microsoft.AspNetCore.Mvc;
using PublishingHouse.Abstractions.Model;
using PublishingHouse.Abstractions.Service;
using PublishingHouse.DAL.Mapper;
using PublishingHouse.WebApi.Dto;
using PublishingHouse.WebApi.Mapper;

namespace PublishingHouse.WebApi.Controller;

[ApiController]
[Route("api/roles")]
public class RoleController(IRoleService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var roles = await service.GetAllAsync();

        return Ok(roles);
    }

    [HttpGet("{id:int:min(1)}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var role = await service.GetByIdAsync(id);
        if (role == null)
        {
            return NotFound();
        }
        return Ok(role);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateRoleDto roleDto)
    {
        var roleInput = roleDto.ToInputModel();
        var role = await service.AddAsync(roleInput);

        return CreatedAtAction(nameof(GetById), new { id = role.RoleId }, role);
    }

    [HttpPut("{id:int:min(1)}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateRoleDto roleDto)
    {
        var existingRole = await service.GetByIdAsync(id);
        if (existingRole == null)
        {
            return NotFound($"Role with ID {id} not found.");
        }

        var roleInput = roleDto.ToInputModel();
        var role = await service.UpdateAsync(id, roleInput);

        if (role == null)
        {
            return BadRequest("Update operation failed.");
        }

        return Ok(role);
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
