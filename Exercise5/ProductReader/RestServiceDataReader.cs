namespace Exercise5.ProductReader;

public class RestServiceDataReader : IRestServiceDataReader
{
    public async Task<string> GetStringContentAsync(string uri)
    {
        using var httpClient = new HttpClient();
        using var response = await httpClient.GetAsync(uri);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStringAsync();
    }
}