using NeverNull;

namespace Exercise5.Analyzer.Article;

public class AnalysedArticle(
    long productId,
    long articleId,
    Option<decimal> pricePerLiter,
    Option<decimal> totalPrice,
    Option<int> numberOfUnits)
{
    public long ProductId { get; } = productId;
    public long ArticleId { get; } = articleId;
    public Option<decimal> PricePerLiter { get; } = pricePerLiter;
    public Option<decimal> TotalPrice { get; } = totalPrice;
    public Option<int> NumberOfUnits { get; } = numberOfUnits;
}