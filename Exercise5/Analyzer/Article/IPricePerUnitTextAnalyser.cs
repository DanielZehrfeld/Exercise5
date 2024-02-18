namespace Exercise5.Analyzer.Article;

internal interface IPricePerUnitTextAnalyser
{
    (decimal pricePerLiter, bool hasError) ResolvePricePerLiter(string pricePerUnit);
}