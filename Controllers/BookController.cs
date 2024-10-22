using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace book_api;

[ApiController]
[Route("api/books")]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;
    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAllAsync()
    {
        var books = await _bookService.GetAllAsync();
        return Ok(books);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        try
        {
            var book = await _bookService.GetByIdAsync(id);
            Log.Information("Book with id {id} was requested", id);
            return Ok(book);
        }
        catch (CustomException e)
        {
            var response = new { e.StatusCode, Error = e.Message };
            return StatusCode(e.StatusCode, response);
        }
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AddAsync([FromBody] CreateBookRequest createBookRequest)
    {
        await _bookService.AddAsync(createBookRequest);
        return Ok();
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateBookPrice(int id, [FromBody] double newPrice)
    {
        try
        {
            await _bookService.UpdatePriceAsync(id, newPrice);
            return Ok();
        }
        catch (CustomException e)
        {
            var response = new { e.StatusCode, Error = e.Message };
            return StatusCode(e.StatusCode, response);
        }
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        try
        {
            await _bookService.DeleteAsync(id);
            return Ok();
        }
        catch (CustomException e)
        {
            var response = new { e.StatusCode, Error = e.Message };
            return StatusCode(e.StatusCode, response);
        }
    }
}
