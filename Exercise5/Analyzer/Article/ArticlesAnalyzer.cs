namespace Exercise5.Analyzer.Article;

internal class ArticlesAnalyzer : IArticlesAnalyzer
{
    private readonly IPricePerUnitTextAnalyser _pricePerUnitTextAnalyser;
    private readonly IShortDescriptionTextAnalyser _shortDescriptionTextAnalyser;

    public ArticlesAnalyzer(IPricePerUnitTextAnalyser pricePerUnitTextAnalyser, IShortDescriptionTextAnalyser shortDescriptionTextAnalyser)
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
        var pricePerLiter = _pricePerUnitTextAnalyser.ResolvePricePerLiter(article.PricePerUnitText);
        var numberOfUnits = _shortDescriptionTextAnalyser.ResolveNumberOfUnits(article.ShortDescription);

        return new AnalysedArticle(article.ProductId,
            article.Id,
            pricePerLiter,
            article.Price,
            numberOfUnits);
    }
}