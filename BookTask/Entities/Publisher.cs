namespace BookTask.Entities;

public class Publisher
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public virtual List<Discount>? Discounts { get; set; }
    public virtual List<Book>? Books { get; set; }
}
