using System.Text.Json.Serialization;

namespace Exercise5.Controllers.Output;

public class PricePerLitreResult(PricePerLitre? min, PricePerLitre? max)
{
    [JsonPropertyName("min")]
    public PricePerLitre? Min { get; } = min;

    [JsonPropertyName("max")]
    public PricePerLitre? Max { get; } = max;
}