using NeverNull;

namespace Exercise5.Analyzer.Article;

internal interface IPricePerUnitTextAnalyser
{
    Option<decimal> ResolvePricePerLiter(string articlePricePerUnitText);
}