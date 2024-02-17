using Exercise5.ProductReader.Input;

namespace Exercise5.ProductReader.Extensions
{
    public static class ArticleExt
    {
        public static Article ConvertArticleToResultProductData(this Input.JsonArticle jsonArticle, long productId)
        {
            return new Article(
                productId: productId,
                articleId: jsonArticle.Id,
                articleUnit: jsonArticle.Unit, //Todo nullwerte, fehlende werte, decimal mit komma, null-arrays!
                articlePrice: jsonArticle.Price,
                articleShortDescription: jsonArticle.ShortDescription,
                articlePricePerUnitText: jsonArticle.pricePerUnitText);
        }
    }
}