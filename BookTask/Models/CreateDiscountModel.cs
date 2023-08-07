namespace BookTask.Models;

public class CreateDiscountModel
{
    public required float Persentage { get; set; }
    public required DateTime StartDate { get; set; }
    public required DateTime EndDate { get; set; }
    public int? BookId { get; set; }
    public int? AuthorId { get; set; }
    public int? PublisherId { get; set; }
}
