using System.Runtime.CompilerServices;
using Exercise5.Analyzer.Article;
using Exercise5.Analyzer.Extensions;
using Exercise5.Controllers.Output;

namespace Exercise5.Analyzer.NumberOfBottles;

internal class NumberOfBottlesAnalyser : INumberOfBottlesAnalyser
{
    public NumberOfBottlesResult GetMaxNumberOfBottlesArticles(IReadOnlyCollection<AnalysedArticle> articles)
    {


        var maxBottleItems = articles
            .Where(a => a.NumberOfUnits.HasValue)
            .GroupBy(a => (int)a.NumberOfUnits!)
            .Select(g => (g.Key, g))
            .OrderBy(g => g.Key)
            .LastOrDefault();


        return maxBottleItems != default
            ? CreateResultItems(maxBottleItems.Key, maxBottleItems.g)
            : new NumberOfBottlesResult(0, Array.Empty<ResultArticle>());
    }

    private NumberOfBottlesResult CreateResultItems(int count, IEnumerable<AnalysedArticle> articles)
    {
        return new NumberOfBottlesResult(count, articles.Select(a => a.ToResultArticle()).ToArray());
    }
}