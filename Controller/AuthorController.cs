using Microsoft.AspNetCore.Mvc;
using PublishingHouse.Abstractions.Service;
using PublishingHouse.DAL.Mapper;
using PublishingHouse.WebApi.Dto;
using PublishingHouse.WebApi.Mapper;

namespace PublishingHouse.WebApi.Controller;

[ApiController]
[Route("api/authors")]
public class AuthorController(IAuthorService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var authors = await service.GetAllAsync();

        return Ok(authors);
    }

    [HttpGet("{id:int:min(1)}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var author = await service.GetByIdAsync(id);

        if (author == null)
        {
            return NotFound();
        }
        return Ok(author);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAuthorDto authorDto)
    {
        var authorInput = authorDto.ToInputModel();
        var author = await service.AddAsync(authorInput);

        return CreatedAtAction(nameof(GetById), new { id = author.AuthorId }, author);
    }

    [HttpPut("{id:int:min(1)}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateAuthorDto authorDto)
    {

        var existingAuthor = await service.GetByIdAsync(id);
        if (existingAuthor == null)
        {
            return NotFound($"Author with ID {id} not found.");
        }
        
        var authorInput = authorDto.ToInputModel();
        var author = await service.UpdateAsync(id, authorInput);

        if (author == null)
        {
            return BadRequest("Update operation failed.");
        }

        return Ok(author);

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