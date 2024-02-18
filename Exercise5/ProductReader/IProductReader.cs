namespace Exercise5.ProductReader;

internal interface IProductReader
{
    Task<IEnumerable<Article>> LoadProductsAsync(string url);
}