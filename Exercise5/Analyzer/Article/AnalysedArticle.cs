namespace Exercise5.Analyzer.Article;

public class AnalysedArticle
{
    public long ProductId { get; }
    public long ArticleId { get; }
    public decimal? PricePerLiter { get; }
    public decimal? TotalPrice { get; }
    public int? NumberOfUnits { get; }

    public AnalysedArticle(long productId,
        long articleId,
        decimal? pricePerLiter,
        decimal? totalPrice,
        int? numberOfUnits)
    {
        ProductId = productId;
        ArticleId = articleId;
        PricePerLiter = pricePerLiter;
        TotalPrice = totalPrice;
        NumberOfUnits = numberOfUnits;
    }
}