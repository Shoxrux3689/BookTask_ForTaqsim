using BookTask.Context;
using BookTask.Entities;
using BookTask.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookTask.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GenresController : ControllerBase
{
    public readonly AppDbContext _appDbContext;

    public GenresController(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    [HttpPost]
    public async Task<IActionResult> CreateGenre([FromBody] CreateGenreModel createGenreModel)
    {
        var genre = new Genre() { Name = createGenreModel.Name };

        _appDbContext.Genres.Add(genre);
        await _appDbContext.SaveChangesAsync();

        return Created("", genre.Id);
    }
}
