using System.Text.Json.Serialization;

namespace Exercise5.Controllers.Output;

public class PricePerLitre
{
    [JsonPropertyName("Price")]
    public decimal Price { get; }

    [JsonPropertyName("Article")]
    public ResultArticle Article { get; }

    public PricePerLitre(decimal price, ResultArticle article)
    {
        Price = price;
        Article = article;
    }
}