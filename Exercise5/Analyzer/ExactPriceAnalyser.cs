using Exercise5.Analyzer.Article;
using Exercise5.Analyzer.Extensions;
using Exercise5.Controllers.Output;

namespace Exercise5.Analyzer;

internal class ExactPriceAnalyser : IExactPriceAnalyser
{
    public ExactPriceResult GetExactPriceItemsResult(IEnumerable<AnalysedArticle> articles, decimal price)
    {
        var resultItems = articles
            .Where(article => article.TotalPrice == price)
            .OrderBy(article => article.PricePerLiter)
            .Select(article => article.ToResultArticle())
            .ToArray();

        return new ExactPriceResult(price, resultItems);
    }
}