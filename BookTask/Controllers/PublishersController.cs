using BookTask.Context;
using BookTask.Entities;
using BookTask.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookTask.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PublishersController : ControllerBase
{
    private readonly AppDbContext _context;

    public PublishersController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> CreatePublisher([FromBody] CreatePublisherModel createPublisherModel)
    {
        var publisher = new Publisher() { Name = createPublisherModel.Name };

        _context.Publishers.Add(publisher);
        await _context.SaveChangesAsync();

        return Created("", publisher.Id);
    }
}
