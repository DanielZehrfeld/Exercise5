using NeverNull;

namespace Exercise5.Analyzer.Article;

internal class PricePerUnitTextAnalyser : IPricePerUnitTextAnalyser
{
    public Option<decimal> ResolvePricePerLiter(string articlePricePerUnitText)
    {
        var result = Option<decimal>.None; 

        var trimmed = articlePricePerUnitText.Trim(' ', '(', ')');
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