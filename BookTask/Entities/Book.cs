namespace BookTask.Entities;

public class Book
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public virtual Publisher? Publisher { get; set; }
    public int PublisherId { get; set; }
    public virtual Author? Author { get; set; }
    public int AuthorId { get; set; }
    public virtual Genre? Genre { get; set; }
    public int GenreId { get; set; }
    public float Price { get; set; }
    public int Year { get; set; }
    public virtual List<Discount>? Discounts { get; set; }
}
