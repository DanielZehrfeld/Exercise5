using Exercise5.ProductReader;

namespace Exercise5.Analyzer.Article;

internal interface IArticleAnalyzer
{
    IReadOnlyCollection<AnalysedArticle> Analyse(IEnumerable<ProductReader.Article> articles);
}