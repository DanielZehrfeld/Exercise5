namespace Exercise5.Analyzer.Article;

public class AnalysedArticle(
    long productId,
    long articleId,
    decimal? pricePerLiter,
    decimal? totalPrice,
    int? numberOfUnits)
{
    public long ProductId { get; } = productId;
    public long ArticleId { get; } = articleId;
    public decimal? PricePerLiter { get; } = pricePerLiter;
    public decimal? TotalPrice { get; } = totalPrice;
    public int? NumberOfUnits { get; } = numberOfUnits;
}