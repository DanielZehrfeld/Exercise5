using Exercise5.Analyzer.Article;
using Exercise5.Analyzer.Extensions;
using Exercise5.Controllers.Output;
using NeverNull.Combinators;

namespace Exercise5.Analyzer;

internal class NumberOfBottlesAnalyser : INumberOfBottlesAnalyser
{
    public NumberOfBottlesResult GetMaxNumberOfBottlesArticles(IEnumerable<AnalysedArticle> articles)
    {
        var maxBottleItems = articles
            .Select(article => article.NumberOfUnits.Select(articleNumberOfUnits => (articleNumberOfUnits, article)))
            .SelectValues()
            .GroupBy(article => article.articleNumberOfUnits, article => article.article)
            .Select(articleGroup => (NumberOfBottles: articleGroup.Key, Items: articleGroup))
            .OrderBy(articleGroup => articleGroup.NumberOfBottles)
            .LastOrDefault();

        return maxBottleItems != default
            ? CreateResultItems(maxBottleItems.NumberOfBottles, maxBottleItems.Items)
            : new NumberOfBottlesResult(0, []);
    }

    private static NumberOfBottlesResult CreateResultItems(int count, IEnumerable<AnalysedArticle> articles)
        => new(
            numberOfBottles: count,
            articles: articles
                .Select(article => article.ToResultArticle())
                .ToArray());
}