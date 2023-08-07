namespace BookTask.Entities;

public class Discount
{
    public int Id { get; set; }
    public float Persentage { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public virtual Book? Book { get; set; }
    public int? BookId { get; set; }
    public virtual Author? Author { get; set; }
    public int? AuthorId { get; set; }
    public virtual Publisher? Publisher { get; set; }
    public int? PublisherId { get; set; }
}
