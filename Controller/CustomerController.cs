using Microsoft.AspNetCore.Mvc;
using PublishingHouse.Abstractions.Model;
using PublishingHouse.Abstractions.Service;
using PublishingHouse.DAL.Mapper;
using PublishingHouse.WebApi.Dto;
using PublishingHouse.WebApi.Mapper;

namespace PublishingHouse.WebApi.Controller;

[ApiController]
[Route("api/customers")]
public class CustomerController(ICustomerService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var customers = await service.GetAllAsync();

        return Ok(customers);
    }

    [HttpGet("{id:int:min(1)}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var customer = await service.GetByIdAsync(id);
        if (customer == null)
        {
            return NotFound();
        }
        return Ok(customer);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCustomerDto customerDto)
    {
        var customerInput = customerDto.ToInputModel();
        var customer = await service.AddAsync(customerInput);

        return CreatedAtAction(nameof(GetById), new { id = customer.CustomerId }, customer);
    }

    [HttpPut("{id:int:min(1)}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCustomerDto customerDto)
    {
        var existingCustomer = await service.GetByIdAsync(id);
        if (existingCustomer == null)
        {
            return NotFound($"Customer with ID {id} not found.");
        }

        var customerInput = customerDto.ToInputModel();
        var customer = await service.UpdateAsync(id, customerInput);

        if (customer == null)
        {
            return BadRequest("Update operation failed.");
        }

        return Ok(customer);
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

    [HttpGet("{id:int:min(1)}/orders")]
    public async Task<IActionResult> GetCustomerWithOrders([FromRoute] int id)
    {
        var customer = await service.GetCustomerWithOrdersAsync(id);
        if (customer == null)
        {
            return NotFound();
        }
        return Ok(customer);
    }
}
