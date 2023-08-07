namespace BookTask.Models;

public class BookModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string PublisherName { get; set; }
    public string AuthorName { get; set; }
    public string GenreName { get; set; }
    public float Price { get; set; }
    public int Year { get; set; }
}
