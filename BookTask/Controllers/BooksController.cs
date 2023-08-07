using BookTask.Managers;
using BookTask.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookTask.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly BookManager _bookManager;

    public BooksController(BookManager bookManager)
    {
        _bookManager = bookManager;
    }

    [HttpPost]
    public async Task<IActionResult> CreateBook([FromBody] CreateBookModel createBookModel)
    {
        var book = await _bookManager.CreateBook(createBookModel);

        return Created("", new { Id = book.Id });
    }

    [HttpGet]
    public async Task<IActionResult> GetBooks([FromQuery] BookFilter bookFilter)
    {
        var books = await _bookManager.GetBooks(bookFilter);
        return Ok(books);
    }
}
