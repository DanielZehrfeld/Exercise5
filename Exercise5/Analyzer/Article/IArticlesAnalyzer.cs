namespace Exercise5.Analyzer.Article;

public interface IArticlesAnalyzer
{
    IReadOnlyCollection<AnalysedArticle> Analyse(IEnumerable<ProductReader.Article> articles);
}