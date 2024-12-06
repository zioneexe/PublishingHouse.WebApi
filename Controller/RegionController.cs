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
    [Route("api/regions")]
    [Authorize(Roles = "Admin")]
    public class RegionController(IRegionService service, IMapper<IRegion, RegionRequestDto, RegionResponseDto> mapper)
        : ControllerBase
    {
        [HttpGet]
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

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RegionRequestDto dto)
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
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] RegionRequestDto dto)
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