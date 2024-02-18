using System.Text.Json;
using Exercise5.ProductReader.Extensions;

namespace Exercise5.ProductReader;

internal class ProductReader(IRestServiceDataReader restServiceDataReader) : IProductReader
{
    public async Task<IEnumerable<Article>> LoadProductsAsync(string url)
    {
        var content = await restServiceDataReader.GetStringContentAsync(url);

        var products = string.IsNullOrEmpty(content)
            ? []
            : JsonSerializer.Deserialize<Input.JsonProduct[]>(content);

        return products?
            .SelectMany(ConvertToResultProductData)
            .ToArray() ?? [];
    }

    private static IEnumerable<Article> ConvertToResultProductData(Input.JsonProduct jsonProduct)
        => jsonProduct
               .Articles?
               .Select(article => article.ConvertArticleToResultProductData(jsonProduct.Id))
               .OfType<Article>()
           ?? [];
}