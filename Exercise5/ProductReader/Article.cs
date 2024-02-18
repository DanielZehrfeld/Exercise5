namespace Exercise5.ProductReader;

internal class Article
{
    public long ProductId { get; }
    public long Id { get; }
    public decimal? Price { get; }
    public string ShortDescription { get; }
    public string PricePerUnitText { get; }

    public Article(long productId,
        long id,
        decimal? price,
        string shortDescription,
        string pricePerUnitText)
    {
        ProductId = productId;
        Id = id;
        Price = price;
        ShortDescription = shortDescription;
        PricePerUnitText = pricePerUnitText;
    }
}