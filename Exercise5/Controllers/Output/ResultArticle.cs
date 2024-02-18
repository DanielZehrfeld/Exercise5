using System.Text.Json.Serialization;

namespace Exercise5.Controllers.Output;

internal class ResultArticle
{
    [JsonPropertyName("ProductId")]
    public long ProductId { get; }

    [JsonPropertyName("ArticleId")]
    public long ArticleId { get; }

    public ResultArticle(long productId, long articleId)
    {
        ProductId = productId;
        ArticleId = articleId;
    }
}