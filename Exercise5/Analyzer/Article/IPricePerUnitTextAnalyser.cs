namespace Exercise5.Analyzer.Article;

internal interface IPricePerUnitTextAnalyser
{
    decimal? ResolvePricePerLiter(string articlePricePerUnitText);
}