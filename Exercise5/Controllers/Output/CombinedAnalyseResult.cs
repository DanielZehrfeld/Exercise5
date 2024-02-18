using System.Text.Json.Serialization;

namespace Exercise5.Controllers.Output;

internal class CombinedAnalyseResult
{
    [JsonPropertyName("ExactPriceResult")]
    public ExactPriceResult ExactPriceResult { get; }

    [JsonPropertyName("NumberOfBottlesResult")]
    public NumberOfBottlesResult NumberOfBottlesResult { get; }

    [JsonPropertyName("PricePerLitreResult")]
    public PricePerLitreResult PricePerLitreResult { get; }

    public CombinedAnalyseResult(ExactPriceResult exactPriceResult,
        NumberOfBottlesResult numberOfBottlesResult,
        PricePerLitreResult pricePerLitreResult)
    {
        ExactPriceResult = exactPriceResult;
        NumberOfBottlesResult = numberOfBottlesResult;
        PricePerLitreResult = pricePerLitreResult;
    }
}