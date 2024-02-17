using System.Text.Json.Serialization;

namespace Exercise5.ProductReader.Input;

public class JsonProduct
{
    [JsonPropertyName("Id")]
    public long? Id { get; set; }

    [JsonPropertyName("BrandName")]
    public string? BrandName { get; set; }

    [JsonPropertyName("Name")]
    public string? Name { get; set; }

    [JsonPropertyName("DescriptionText")]
    public string? DescriptionText { get; set; }

    [JsonPropertyName("Articles")]
    public JsonArticle[]? Articles { get; set; }
}