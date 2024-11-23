using Microsoft.AspNetCore.Mvc;
using PublishingHouse.Abstractions.Model;
using PublishingHouse.Abstractions.Service;
using PublishingHouse.DAL.Mapper;
using PublishingHouse.WebApi.Dto;
using PublishingHouse.WebApi.Mapper;

namespace PublishingHouse.WebApi.Controller;

[ApiController]
[Route("api/customertypes")]
public class CustomerTypeController(ICustomerTypeService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var customerTypes = await service.GetAllAsync();

        return Ok(customerTypes);
    }

    [HttpGet("{id:int:min(1)}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var customerType = await service.GetByIdAsync(id);
        if (customerType == null)
        {
            return NotFound();
        }
        return Ok(customerType);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCustomerTypeDto customerTypeDto)
    {
        var customerTypeInput = customerTypeDto.ToInputModel();
        var customerType = await service.AddAsync(customerTypeInput);

        return CreatedAtAction(nameof(GetById), new { id = customerType.CustomerTypeId }, customerType);
    }

    [HttpPut("{id:int:min(1)}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCustomerTypeDto customerTypeDto)
    {
        var existingCustomerType = await service.GetByIdAsync(id);
        if (existingCustomerType == null)
        {
            return NotFound($"Customer type with ID {id} not found.");
        }

        var customerTypeInput = customerTypeDto.ToInputModel();
        var customerType = await service.UpdateAsync(id, customerTypeInput);

        if (customerType == null)
        {
            return BadRequest("Update operation failed.");
        }

        return Ok(customerType);
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

    [HttpGet("{id:int:min(1)}/customers")]
    public async Task<IActionResult> GetCustomerTypeWithCustomers([FromRoute] int id)
    {
        var customerType = await service.GetCustomerTypeWithCustomersAsync(id);
        if (customerType == null)
        {
            return NotFound();
        }
        return Ok(customerType);
    }
}
