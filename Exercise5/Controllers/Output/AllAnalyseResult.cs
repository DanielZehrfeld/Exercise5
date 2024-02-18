using System.Text.Json.Serialization;

namespace Exercise5.Controllers.Output;

public class AllAnalyseResult(
    ExactPriceResult exactPriceResult,
    NumberOfBottlesResult numberOfBottlesResult,
    PricePerLitreResult pricePerLitreResult)
{
    [JsonPropertyName("exactPrice")]
    public ExactPriceResult ExactPriceResult { get; } = exactPriceResult;

    [JsonPropertyName("maxNumberOfBottles")]
    public NumberOfBottlesResult NumberOfBottlesResult { get; } = numberOfBottlesResult;

    [JsonPropertyName("pricePerLitre")]
    public PricePerLitreResult PricePerLitreResult { get; } = pricePerLitreResult;
}