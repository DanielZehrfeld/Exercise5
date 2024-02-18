using Exercise5.ProductReader.Input;

namespace Exercise5.ProductReader.Extensions;

internal static class ArticleExt
{
    public static Article? ConvertArticleToResultProductData(this JsonArticle jsonArticle, long? productId)
    {
        var isValid = productId.HasValue && jsonArticle.Id.HasValue;

        return isValid
            ? new Article(
                productId: productId ?? 0,
                articleId: jsonArticle.Id ?? 0,
                articleUnit: jsonArticle.Unit ?? string.Empty,
                articlePrice: jsonArticle.Price,
                articleShortDescription: jsonArticle.ShortDescription ?? string.Empty,
                articlePricePerUnitText: jsonArticle.PricePerUnitText ?? string.Empty)
            : default;
    }
}