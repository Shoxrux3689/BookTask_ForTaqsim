namespace BookTask.Models;

public class CreateBookModel
{
    public required string Name { get; set; }
    public required int PublisherId { get; set; }
    public required int AuthorId { get; set; }
    public required int GenreId { get; set; }
    public required float Price { get; set; }
    public required int Year { get; set; }
}
