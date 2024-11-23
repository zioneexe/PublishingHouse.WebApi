using Microsoft.AspNetCore.Mvc;
using PublishingHouse.Abstractions.Model;
using PublishingHouse.Abstractions.Service;
using PublishingHouse.DAL.Mapper;
using PublishingHouse.WebApi.Dto;
using PublishingHouse.WebApi.Mapper;

namespace PublishingHouse.WebApi.Controller;

[ApiController]
[Route("api/employees")]
public class EmployeeController(IEmployeeService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var employees = await service.GetAllAsync();

        return Ok(employees);
    }

    [HttpGet("{id:int:min(1)}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var employee = await service.GetByIdAsync(id);
        if (employee == null)
        {
            return NotFound();
        }
        return Ok(employee);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateEmployeeDto employeeDto)
    {
        var employeeInput = employeeDto.ToInputModel();
        var employee = await service.AddAsync(employeeInput);

        return CreatedAtAction(nameof(GetById), new { id = employee.EmployeeId }, employee);
    }

    [HttpPut("{id:int:min(1)}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateEmployeeDto employeeDto)
    {
        var existingEmployee = await service.GetByIdAsync(id);
        if (existingEmployee == null)
        {
            return NotFound($"Employee with ID {id} not found.");
        }

        var employeeInput = employeeDto.ToInputModel();
        var employee = await service.UpdateAsync(id, employeeInput);

        if (employee == null)
        {
            return BadRequest("Update operation failed.");
        }

        return Ok(employee);
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
