using System.Text.Json;
using Exercise5.ProductReader.Extensions;

namespace Exercise5.ProductReader
{
    public class ProductReader : IProductReader
    {
        private readonly IRestServiceDataReader _restServiceDataReader;

        public ProductReader(IRestServiceDataReader restServiceDataReader)
        {
            _restServiceDataReader = restServiceDataReader;
        }


        public async Task<IEnumerable<Article>> LoadProductsAsync(string url)
        {
            var content = await _restServiceDataReader.GetStringContentAsync(url);

            var products = JsonSerializer.Deserialize<Input.JsonProduct[]>(content); //todo null results

            return products.SelectMany(ConvertToResultProductData);
        }

        private static IEnumerable<Article> ConvertToResultProductData(Input.JsonProduct jsonProduct)
        {
            return jsonProduct.Articles.Select(article => article.ConvertArticleToResultProductData(jsonProduct.Id)); //todo nu
        }
    }
}