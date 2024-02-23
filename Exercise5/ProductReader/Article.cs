using NeverNull;

namespace Exercise5.ProductReader;

public class Article(
    long productId,
    long id,
    Option<decimal> price,
    string shortDescription,
    string pricePerUnitText)
{
    public long ProductId { get; } = productId;
    public long Id { get; } = id;
    public Option<decimal> Price { get; } = price;
    public string ShortDescription { get; } = shortDescription;
    public string PricePerUnitText { get; } = pricePerUnitText;
}