namespace Exercise5.ProductReader;

public interface IRestServiceDataReader
{
    Task<string> GetStringContentAsync(string uri);
}