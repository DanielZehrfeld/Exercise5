using Exercise5.ProductReader;

namespace Exercise5.Analyzer.Article;

public interface IArticleAnalyzer
{
    IReadOnlyCollection<AnalysedArticle> Analyse(IEnumerable<ProductReader.Article> articles);
}