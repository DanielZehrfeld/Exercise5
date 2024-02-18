using System.Text.Json.Serialization;

namespace Exercise5.Controllers.Output;

internal class PricePerLitreResult
{
    [JsonPropertyName("Min")]
    public PricePerLitre Min { get; }

    [JsonPropertyName("Max")]
    public PricePerLitre Max { get; }

    public PricePerLitreResult(PricePerLitre max, PricePerLitre min)
    {
        Max = max;
        Min = min;
    }
}