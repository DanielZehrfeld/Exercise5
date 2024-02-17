using Exercise5.ProductReader;

namespace Exercise5.Analyzer.Article
{
    public class ArticleAnalyzer : IArticleAnalyzer
    {
        public IEnumerable<AnalysedArticle> Analyse(IEnumerable<Article> articles)
        {
            return articles.Select(AnalyseArticle);
        }


        private AnalysedArticle AnalyseArticle(Article article)
        {




        }
    }
}
