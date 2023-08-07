using BookTask.Context;
using BookTask.Entities;
using BookTask.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookTask.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DiscountsController : ControllerBase
{
    private readonly AppDbContext _appDbContext;

    public DiscountsController(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    [HttpPost]
    public async Task<IActionResult> CreateDiscount([FromBody] CreateDiscountModel createDiscount)
    {
        if (createDiscount.AuthorId == null
            && createDiscount.BookId == null
            && createDiscount.PublisherId == null)
            return BadRequest("Discount nimaga tegishli ekanligini korsating");

        var discount = new Discount()
        {
            Persentage = createDiscount.Persentage,
            StartDate = createDiscount.StartDate,
            EndDate = createDiscount.EndDate,
            BookId = createDiscount.BookId,
            PublisherId = createDiscount.PublisherId,
            AuthorId = createDiscount.AuthorId,
        };

        _appDbContext.Discounts.Add(discount);
        await _appDbContext.SaveChangesAsync();

        return Created("", new { Id = discount.Id });
    }
}
