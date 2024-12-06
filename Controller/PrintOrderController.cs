using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PublishingHouse.Abstractions.Entity;
using PublishingHouse.Abstractions.Exception;
using PublishingHouse.Abstractions.Service;
using PublishingHouse.WebApi.Dto;
using PublishingHouse.WebApi.Dto.Request;
using PublishingHouse.WebApi.Dto.Response;
using PublishingHouse.WebApi.Mapper;
using PublishingHouse.WebApi.Mapper.General;

namespace PublishingHouse.WebApi.Controller
{
    [ApiController]
    [Route("api/orders")]
    public class PrintOrderController(IPrintOrderService service, IMapper<IPrintOrder, PrintOrderRequestDto, PrintOrderResponseDto> mapper) : ControllerBase
    {
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await service.GetAllAsync();
                return Ok(response.Select(mapper.ToResponseDto));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("{id:int:min(1)}")]
        [Authorize(Roles = "Admin, Employee")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                var response = await service.GetByIdAsync(id);
                return Ok(mapper.ToResponseDto(response));
            }
            catch (RepositoryException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("employee/{employeeId:int:min(1)}")]
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> GetByEmployeeId([FromRoute] int employeeId)
        {
            try
            {
                var response = await service.GetByEmployeeIdAsync(employeeId);
                return Ok(response.Select(mapper.ToResponseDto));
            }
            catch (RepositoryException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("customer/{customerId:int:min(1)}")]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> GetByCustomerId([FromRoute] int customerId)
        {
            try
            {
                var response = await service.GetByCustomerIdAsync(customerId);
                return Ok(response.Select(mapper.ToResponseDto));
            }
            catch (RepositoryException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] PrintOrderRequestDto dto)
        {
            try
            {
                await service.AddAsync(mapper.ToEntity(dto));
                return Created();
            }
            catch (RepositoryException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost("order-id")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateWithId([FromBody] PrintOrderRequestDto dto)
        {
            try
            {
                var orderId = await service.AddWithIdAsync(mapper.ToEntity(dto));
                return CreatedAtAction(nameof(CreateWithId), new { id = orderId }, new { orderId = orderId });
            }
            catch (RepositoryException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPut("{id:int:min(1)}")]
        [Authorize(Roles = "Admin, Employee")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] PrintOrderRequestDto dto)
        {
            try
            {
                await service.UpdateAsync(id, mapper.ToEntity(dto));
                return NoContent();
            }
            catch (RepositoryException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpDelete("{id:int:min(1)}")]
        [Authorize(Roles = "Admin, Employee, Customer")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                await service.DeleteAsync(id);
                return NoContent();
            }
            catch (RepositoryException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPut("{orderId:int:min(1)}/cancel")]
        [Authorize(Roles = "Customer, Admin")]
        public async Task<IActionResult> CancelOrder([FromRoute] int orderId)
        {
            try
            {
                await service.CancelOrderAsync(orderId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
