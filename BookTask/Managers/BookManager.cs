using BookTask.Context;
using BookTask.Entities;
using BookTask.Extensions;
using BookTask.Models;
using Microsoft.EntityFrameworkCore;

namespace BookTask.Managers;

public class BookManager
{
    private readonly AppDbContext _context;

    public BookManager(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Book> CreateBook(CreateBookModel createBookModel)
    {
        var book = new Book()
        {
            Name = createBookModel.Name,
            AuthorId = createBookModel.AuthorId,
            PublisherId = createBookModel.PublisherId,
            GenreId = createBookModel.GenreId,
            Year = createBookModel.Year,
            Price = createBookModel.Price,
        };
        _context.Books.Add(book);
        await _context.SaveChangesAsync();

        return book;
    }

    public async Task<List<BookModel>?> GetBooks(BookFilter bookFilter)
    {
        var query = _context.Books.Include(b => b.Discounts)
            .Include(b => b.Author).Include(b => b.Publisher)
            .Include(b => b.Genre).AsQueryable();

        if (!string.IsNullOrWhiteSpace(bookFilter.Name))
            query = query.Where(b => b.Name.Contains(bookFilter.Name));

        if (!string.IsNullOrWhiteSpace(bookFilter.AuthorName))
            query = query.Where(b => b.Author.Name.Contains(bookFilter.AuthorName));

        if (!string.IsNullOrWhiteSpace(bookFilter.PublisherName))
            query = query.Where(b => b.Publisher.Name.Contains(bookFilter.PublisherName));

        if (!string.IsNullOrWhiteSpace(bookFilter.GenreName))
            query = query.Where(b => b.Genre.Name.Contains(bookFilter.GenreName));

        var discounts = _context.Discounts.ToList();

        var books = await query.Select(b => b.ToModel(discounts)).ToListAsync();

        if (bookFilter.PriceFrom == null && bookFilter.PriceTo == null)
            return books;

        if (bookFilter.PriceTo == null && bookFilter.PriceFrom != null)
            return books.Where(b => b.Price > bookFilter.PriceFrom).ToList();

        if (bookFilter.PriceTo != null && bookFilter.PriceFrom != null)
            return books.Where(b => b.Price > bookFilter.PriceFrom && b.Price < bookFilter.PriceTo).ToList();

        return books.Where(b => b.Price > 0 && b.Price < bookFilter.PriceTo).ToList();
    }

}
