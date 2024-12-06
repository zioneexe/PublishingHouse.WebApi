using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PublishingHouse.Abstractions.Entity;
using PublishingHouse.Abstractions.Exception;
using PublishingHouse.Abstractions.Service;
using PublishingHouse.WebApi.Dto;
using PublishingHouse.WebApi.Dto.Request;
using PublishingHouse.WebApi.Dto.Response;
using PublishingHouse.WebApi.Mapper.General;

namespace PublishingHouse.WebApi.Controller
{
    [ApiController]
    [Route("api/productions")]
    [Authorize(Roles = "Admin")]
    public class ProductionController(IProductionService service, IMapper<IProduction, ProductionRequestDto, ProductionResponseDto> mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var productions = await service.GetAllAsync();
                return Ok(productions.Select(mapper.ToResponseDto));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("{id:int:min(1)}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                var production = await service.GetByIdAsync(id);
                return Ok(mapper.ToResponseDto(production));
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
        public async Task<IActionResult> Create([FromBody] ProductionRequestDto dto)
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
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] ProductionRequestDto dto)
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
    }
}
