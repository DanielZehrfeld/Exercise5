namespace Exercise5.ProductReader;

public class Article
{
    public long ProductId { get; }
    public long ArticleId { get; }
    public string ArticleUnit { get; }
    public decimal? ArticlePrice { get; }
    public string ArticleShortDescription { get; }
    public string ArticlePricePerUnitText { get; }

    public Article(long productId,
        long articleId,
        string articleUnit,
        decimal? articlePrice,
        string articleShortDescription,
        string articlePricePerUnitText)
    {
        ProductId = productId;
        ArticleId = articleId;
        ArticleUnit = articleUnit;
        ArticlePrice = articlePrice;
        ArticleShortDescription = articleShortDescription;
        ArticlePricePerUnitText = articlePricePerUnitText;
    }
}