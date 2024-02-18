using Exercise5.ProductReader;

namespace Exercise5.Analyzer.Article;

internal interface IArticlesAnalyzer
{
    IReadOnlyCollection<AnalysedArticle> Analyse(IEnumerable<ProductReader.Article> articles);
}