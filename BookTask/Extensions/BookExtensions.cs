using BookTask.Entities;
using BookTask.Models;

namespace BookTask.Extensions;

public static class BookExtensions
{
    public static BookModel ToModel(this Book book, List<Discount>? discounts)
    {

        var bookModel = new BookModel()
        {
            Id = book.Id,
            Name = book.Name,
            PublisherName = book.Publisher.Name,
            AuthorName = book.Author.Name,
            GenreName = book.Genre.Name,
            Year = book.Year,
        };

        if (discounts == null) 
            return bookModel;

        var discount = discounts
            .Where(d =>
            d.EndDate.Date > DateTime.Now.Date
            && d.AuthorId == book.Author.Id
            || d.PublisherId == book.Publisher.Id
            || d.BookId == book.Id).MaxBy(d => d.Persentage);

        if (discount == null)
            bookModel.Price = book.Price;
        else
        {
            var price = book.Price
            - discount.Persentage * book.Price / 100;

            bookModel.Price = price;
        }

        return bookModel;
    }
}
//.Where(d => d.EndDate.Date<DateTime.Now.Date).Max(d => d.Persentage)