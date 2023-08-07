namespace BookTask.Entities;

public class Genre
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public virtual List<Book>? Books { get; set; }
}
