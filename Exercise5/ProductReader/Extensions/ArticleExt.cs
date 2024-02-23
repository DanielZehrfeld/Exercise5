using Exercise5.ProductReader.Input;
using NeverNull;
using NeverNull.Combinators;

namespace Exercise5.ProductReader.Extensions;

internal static class ArticleExt
{
    public static Option<Article> ConvertArticleToResultProductData(this JsonArticle jsonArticle, Option<long> productId)
        => jsonArticle.Id.ToOption()
            .Zip(productId, (articleIdValue, productIdValue) => (articleIdValue, productIdValue))
            .Match(id => new Article(
                    productId: id.productIdValue,
                    id: id.articleIdValue,
                    price: jsonArticle.Price.ToOption(),
                    shortDescription: jsonArticle.ShortDescription ?? string.Empty,
                    pricePerUnitText: jsonArticle.PricePerUnitText ?? string.Empty),
                () => Option<Article>.None);
}