using Microsoft.AspNetCore.Mvc;
using PublishingHouse.Abstractions.Model;
using PublishingHouse.Abstractions.Service;
using PublishingHouse.DAL.Mapper;
using PublishingHouse.WebApi.Dto;
using PublishingHouse.WebApi.Mapper;

namespace PublishingHouse.WebApi.Controller;

[ApiController]
[Route("api/genres")]
public class GenreController(IGenreService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var genres = await service.GetAllAsync();

        return Ok(genres);
    }

    [HttpGet("{id:int:min(1)}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var genre = await service.GetByIdAsync(id);
        if (genre == null)
        {
            return NotFound();
        }
        return Ok(genre);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateGenreDto genreDto)
    {
        var genreInput = genreDto.ToInputModel();
        var genre = await service.AddAsync(genreInput);

        return CreatedAtAction(nameof(GetById), new { id = genre.GenreId }, genre);
    }

    [HttpPut("{id:int:min(1)}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateGenreDto genreDto)
    {
        var existingGenre = await service.GetByIdAsync(id);
        if (existingGenre == null)
        {
            return NotFound($"Genre with ID {id} not found.");
        }

        var genreInput = genreDto.ToInputModel();
        var genre = await service.UpdateAsync(id, genreInput);

        if (genre == null)
        {
            return BadRequest("Update operation failed.");
        }

        return Ok(genre);
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

    [HttpGet("{id:int:min(1)}/books")]
    public async Task<IActionResult> GetGenreWithBooks([FromRoute] int id)
    {
        var genre = await service.GetGenreWithBooksAsync(id);
        if (genre == null)
        {
            return NotFound();
        }
        return Ok(genre);
    }
}
