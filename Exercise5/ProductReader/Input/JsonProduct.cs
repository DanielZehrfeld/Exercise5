using System.Text.Json.Serialization;

namespace Exercise5.ProductReader.Input;

internal class JsonProduct
{
    [JsonPropertyName("id")]
    public long? Id { get; set; }

    [JsonPropertyName("brandName")]
    public string? BrandName { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("descriptionText")]
    public string? DescriptionText { get; set; }

    [JsonPropertyName("articles")]
    public JsonArticle[]? Articles { get; set; }
}