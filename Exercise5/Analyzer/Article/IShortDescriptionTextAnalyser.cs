using NeverNull;

namespace Exercise5.Analyzer.Article;

internal interface IShortDescriptionTextAnalyser
{
    Option<int> ResolveNumberOfUnits(string shortDescription);
}