using Exercise5.Analyzer.Article;
using Exercise5.Controllers.Output;

namespace Exercise5.Analyzer;

public interface IExactPriceAnalyser
{
    ExactPriceResult GetExactPriceItemsResult(IEnumerable<AnalysedArticle> articles, decimal price);
}