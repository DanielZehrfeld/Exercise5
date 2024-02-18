namespace Exercise5.ProductReader;

internal interface IRestServiceDataReader
{
    Task<string> GetStringContentAsync(string uri);
}