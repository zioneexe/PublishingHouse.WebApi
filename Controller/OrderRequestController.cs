using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PublishingHouse.Abstractions.Entity;
using PublishingHouse.Abstractions.Exception;
using PublishingHouse.Abstractions.Service;
using PublishingHouse.WebApi.Dto.Request;
using PublishingHouse.WebApi.Dto.Response;
using PublishingHouse.WebApi.Mapper.General;

namespace PublishingHouse.WebApi.Controller
{
    [ApiController]
    [Route("api/order-requests")]
    public class OrderRequestController(
        IOrderRequestService service,
        IMapper<IOrderRequest, OrderRequestRequestDto, OrderRequestResponseDto> mapper) : ControllerBase
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
        [Authorize(Roles = "Admin, Customer")]
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

        [HttpGet("customer/{customerId:int:min(1)}")]
        [Authorize(Roles = "Admin, Customer")]
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

        [HttpPost("upload-file")]
        [Authorize(Roles = "Admin, Customer")]
        public async Task<IActionResult> UploadFileAsync([FromForm] FileUploadDto fileDto)
        {
            try
            {
                if (fileDto.File == null || fileDto.File.Length == 0)
                    return BadRequest("No file uploaded.");

                var filePath = await service.SaveFileAsync(fileDto.File);
                return Ok(new { FilePath = filePath });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Customer")]
        public async Task<IActionResult> Create([FromBody] OrderRequestRequestDto dto)
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

        [HttpPut("{id:int:min(1)}")]
        [Authorize(Roles = "Admin, Customer")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] OrderRequestRequestDto dto)
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
        [Authorize(Roles = "Admin, Customer")]
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

        [HttpPost("calculate-price")]
        [Authorize(Roles = "Admin")]
        public IActionResult CalculatePrice([FromBody] OrderRequestRequestDto dto)
        {
            try
            {
                var price = service.CalculatePrice(mapper.ToEntity(dto));
                return Ok(price);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
