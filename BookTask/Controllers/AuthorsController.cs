using BookTask.Context;
using BookTask.Entities;
using BookTask.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookTask.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorsController : ControllerBase
{
    private readonly AppDbContext _context;

    public AuthorsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAuthor([FromBody] CreateAuthorModel createAuthorModel)
    {
        var author = new Author() { Name = createAuthorModel.Name };
        _context.Authors.Add(author);
        await _context.SaveChangesAsync();

        return Created("", new {Id = author.Id });
    }
}
