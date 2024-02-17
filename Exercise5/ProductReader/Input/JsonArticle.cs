using System.Text.Json.Serialization;

namespace Exercise5.ProductReader.Input;

public class JsonArticle
{
    [JsonPropertyName("Id")]
    public long? Id { get; set; }

    [JsonPropertyName("ShortDescription")]
    public string? ShortDescription { get; set; }

    [JsonPropertyName("Price")]
    public decimal? Price { get; set; }

    [JsonPropertyName("Unit")]
    public string? Unit { get; set; }

    [JsonPropertyName("PricePerUnitText")]
    public string? PricePerUnitText { get; set; }

    [JsonPropertyName("Image")]
    public string? Image { get; set; }
}