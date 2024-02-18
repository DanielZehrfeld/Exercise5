namespace Exercise5.Analyzer.Article;

internal class ArticlesAnalyzer(IPricePerUnitTextAnalyser pricePerUnitTextAnalyser, IShortDescriptionTextAnalyser shortDescriptionTextAnalyser)
    : IArticlesAnalyzer
{
    public IReadOnlyCollection<AnalysedArticle> Analyse(IEnumerable<ProductReader.Article> articles)
        => articles
            .Select(AnalyseArticle)
            .ToArray();

    private AnalysedArticle AnalyseArticle(ProductReader.Article article)
    {
        var pricePerLiter = pricePerUnitTextAnalyser.ResolvePricePerLiter(article.PricePerUnitText);
        var numberOfUnits = shortDescriptionTextAnalyser.ResolveNumberOfUnits(article.ShortDescription);

        return new AnalysedArticle(article.ProductId,
            article.Id,
            pricePerLiter,
            article.Price,
            numberOfUnits);
    }
}