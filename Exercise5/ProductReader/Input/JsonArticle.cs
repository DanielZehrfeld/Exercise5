using System.Text.Json.Serialization;

namespace Exercise5.ProductReader.Input;

public class JsonArticle
{
    [JsonPropertyName("id")]
    public long? Id { get; set; }

    [JsonPropertyName("shortDescription")]
    public string? ShortDescription { get; set; }

    [JsonPropertyName("price")]
    public decimal? Price { get; set; }

    [JsonPropertyName("unit")]
    public string? Unit { get; set; }

    [JsonPropertyName("pricePerUnitText")]
    public string? PricePerUnitText { get; set; }

    [JsonPropertyName("image")]
    public string? Image { get; set; }
}