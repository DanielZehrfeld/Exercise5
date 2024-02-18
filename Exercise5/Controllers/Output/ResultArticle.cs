using System.Text.Json.Serialization;

namespace Exercise5.Controllers.Output;

public class ResultArticle
{
    [JsonPropertyName("ProductId")]
    public long ProductId { get; }

    [JsonPropertyName("Id")]
    public long ArticleId { get; }

    public ResultArticle(long productId, long articleId)
    {
        ProductId = productId;
        ArticleId = articleId;
    }
}