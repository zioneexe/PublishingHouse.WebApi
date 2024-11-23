using Microsoft.AspNetCore.Mvc;
using PublishingHouse.Abstractions.Model;
using PublishingHouse.Abstractions.Service;
using PublishingHouse.DAL.Mapper;
using PublishingHouse.WebApi.Dto;
using PublishingHouse.WebApi.Mapper;

namespace PublishingHouse.WebApi.Controller;

[ApiController]
[Route("api/books")]
public class BookController(IBookService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var books = await service.GetAllAsync();

        return Ok(books);
    }

    [HttpGet("{id:int:min(1)}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var book = await service.GetByIdAsync(id);
        if (book == null)
        {
            return NotFound();
        }
        return Ok(book);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateBookDto bookDto)
    {
        var bookInput = bookDto.ToInputModel();
        var book = await service.AddAsync(bookInput);

        return CreatedAtAction(nameof(GetById), new { id = book.BookId }, book);
    }

    [HttpPut("{id:int:min(1)}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateBookDto bookDto)
    {
        var existingBook = await service.GetByIdAsync(id);
        if (existingBook == null)
        {
            return NotFound($"Book with ID {id} not found.");
        }

        var bookInput = bookDto.ToInputModel();
        var book = await service.UpdateAsync(id, bookInput);

        if (book == null)
        {
            return BadRequest("Update operation failed.");
        }

        return Ok(book);
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
