namespace Exercise5.ProductReader;

public interface IProductReader
{
    Task<IEnumerable<Article>> LoadProductsAsync(string url);
}