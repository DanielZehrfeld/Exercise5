namespace Exercise5.Analyzer.Article;

public class PricePerUnitTextAnalyser : IPricePerUnitTextAnalyser
{
    public (decimal pricePerLiter, bool hasError) ResolvePricePerLiter(string pricePerUnit)
    {

        var trimmed = pricePerUnit.Trim(' ', '(', ')');

        var unitPosition = trimmed.IndexOf("€/Liter", StringComparison.Ordinal);

        if (unitPosition > 0)
        {
            var priceString = trimmed.Substring(0, unitPosition);


            if (decimal.TryParse(priceString, out var result))
            {

            }



        }


        return (0, true); // ToDo
    }
}