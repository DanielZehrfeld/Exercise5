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
                id: jsonArticle.Id ?? 0,
                price: jsonArticle.Price,
                shortDescription: jsonArticle.ShortDescription ?? string.Empty,
                pricePerUnitText: jsonArticle.PricePerUnitText ?? string.Empty)
            : default;
    }
}