using System.Text.Json.Serialization;

namespace Exercise5.Controllers.Output;

public class NumberOfBottlesResult(int numberOfBottles, ResultArticle[] articles)
{
    [JsonPropertyName("numberOfBottles")]
    public int NumberOfBottles { get; } = numberOfBottles;

    [JsonPropertyName("articles")]
    public ResultArticle[] Articles { get; } = articles;
}