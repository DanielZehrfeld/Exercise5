using Exercise5.Analyzer.Article;
using Exercise5.Analyzer.Extensions;
using Exercise5.Controllers.Output;

namespace Exercise5.Analyzer;

internal class NumberOfBottlesAnalyser : INumberOfBottlesAnalyser
{
    public NumberOfBottlesResult GetMaxNumberOfBottlesArticles(IEnumerable<AnalysedArticle> articles)
    {
        var maxBottleItems = articles
            .Where(article => article.NumberOfUnits.HasValue)
            .GroupBy(article => (int) article.NumberOfUnits!)
            .Select(articleGroup => (NumberOfBottles: articleGroup.Key, Items: articleGroup))
            .OrderBy(articleGroup => articleGroup.NumberOfBottles)
            .LastOrDefault();

        return maxBottleItems != default
            ? CreateResultItems(maxBottleItems.NumberOfBottles, maxBottleItems.Items)
            : new NumberOfBottlesResult(0, Array.Empty<ResultArticle>());
    }

    private static NumberOfBottlesResult CreateResultItems(int count, IEnumerable<AnalysedArticle> articles)
        => new(
            numberOfBottles: count,
            articles: articles
                .Select(article => article.ToResultArticle())
                .ToArray());
}