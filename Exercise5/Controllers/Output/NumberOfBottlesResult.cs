using System.Text.Json.Serialization;

namespace Exercise5.Controllers.Output;

internal class NumberOfBottlesResult
{
    [JsonPropertyName("NumberOfBottles")]
    public int NumberOfBottles { get; }

    [JsonPropertyName("Articles")]
    public ResultArticle[] Articles { get; }

    public NumberOfBottlesResult(int numberOfBottles, ResultArticle[] articles)
    {
        NumberOfBottles = numberOfBottles;
        Articles = articles;
    }
}