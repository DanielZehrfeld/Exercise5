namespace Exercise5.Controllers.Output
{
    public class CombinedAnalyseResult
    {
        public ExactPriceResult ExactPriceResult { get; }
        public NumberOfBottlesResult NumberOfBottlesResult { get; }
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
}