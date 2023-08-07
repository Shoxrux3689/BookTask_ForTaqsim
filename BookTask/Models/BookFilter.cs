using Microsoft.AspNetCore.Mvc;

namespace BookTask.Models;

public class BookFilter
{
    [FromQuery(Name = "name")]
    public string? Name { get; set; }
    [FromQuery(Name = "author")]
    public string? AuthorName { get; set; }
    [FromQuery(Name = "publisher")]
    public string? PublisherName { get; set; }
    [FromQuery(Name = "genre")]
    public string? GenreName { get; set; }
    [FromQuery(Name = "priceFrom")]
    public float? PriceFrom { get; set; }
    [FromQuery(Name = "priceTo")]
    public float? PriceTo { get; set; }
}
