namespace Exercise5.Analyzer.Article;

internal class ArticleAnalyzer : IArticleAnalyzer
{
    private readonly IPricePerUnitTextAnalyser _pricePerUnitTextAnalyser;
    private readonly IShortDescriptionTextAnalyser _shortDescriptionTextAnalyser;

    public ArticleAnalyzer(IPricePerUnitTextAnalyser pricePerUnitTextAnalyser, IShortDescriptionTextAnalyser shortDescriptionTextAnalyser)
    {
        _pricePerUnitTextAnalyser = pricePerUnitTextAnalyser;
        _shortDescriptionTextAnalyser = shortDescriptionTextAnalyser;
    }

    public IReadOnlyCollection<AnalysedArticle> Analyse(IEnumerable<ProductReader.Article> articles)
        => articles
            .Select(AnalyseArticle)
            .ToArray();

    private AnalysedArticle AnalyseArticle(ProductReader.Article article)
    {
        var pricePerLiter = _pricePerUnitTextAnalyser.ResolvePricePerLiter(article.ArticlePricePerUnitText);
        var numberOfUnits = _shortDescriptionTextAnalyser.ResolveNumberOfUnits(article.ArticleShortDescription);

        return new AnalysedArticle(article.ProductId,
            article.ArticleId,
            pricePerLiter,
            article.ArticlePrice,
            numberOfUnits);
    }
}