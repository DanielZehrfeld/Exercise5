using Exercise5.Analyzer.Article;
using Exercise5.Controllers.Output;

namespace Exercise5.Analyzer.Extensions;

internal static class AnalysedArticleExt
{
    public static ResultArticle ToResultArticle(this AnalysedArticle item)
        => new(item.ProductId, item.ArticleId);
}