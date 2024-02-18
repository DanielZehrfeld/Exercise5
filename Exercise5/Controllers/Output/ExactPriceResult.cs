using System.Text.Json.Serialization;

namespace Exercise5.Controllers.Output;

public class ExactPriceResult(decimal price, ResultArticle[] articles)
{
    [JsonPropertyName("price")]
    public decimal Price { get; } = price;

    [JsonPropertyName("articles")]
    public ResultArticle[] Articles { get; } = articles;
}