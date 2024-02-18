namespace Exercise5.Analyzer.Article;

internal class PricePerUnitTextAnalyser : IPricePerUnitTextAnalyser
{
    public decimal? ResolvePricePerLiter(string pricePerUnit)
    {
        decimal? result = default;

        var trimmed = pricePerUnit.Trim(' ', '(', ')');
        var unitPosition = trimmed.IndexOf("€/Liter", StringComparison.Ordinal);

        if (unitPosition > 0)
        {
            var priceString = trimmed[..unitPosition];

            if (decimal.TryParse(priceString, out var parseResult))
            {
                result = parseResult;
            }
        }

        return result;
    }
}