using System.Text.Json.Serialization;

namespace Exercise5.Controllers.Output;

internal class ExactPriceResult
{
    [JsonPropertyName("Price")]
    public decimal Price { get; }

    [JsonPropertyName("Articles")]
    public ResultArticle[] Articles { get; }

    public ExactPriceResult(decimal price, ResultArticle[] articles)
    {
        Price = price;
        Articles = articles;
    }
}