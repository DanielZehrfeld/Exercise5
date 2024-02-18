using System.Text.Json.Serialization;

namespace Exercise5.Controllers.Output;

public class ResultArticle(long productId, long articleId)
{
    [JsonPropertyName("productId")]
    public long ProductId { get; } = productId;

    [JsonPropertyName("articleId")]
    public long ArticleId { get; } = articleId;
}