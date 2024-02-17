namespace Exercise5.Analyzer.Article;

public interface IPricePerUnitTextAnalyser
{
    (decimal pricePerLiter, bool hasError) ResolvePricePerLiter(string pricePerUnit);
}