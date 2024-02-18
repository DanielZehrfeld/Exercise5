namespace Exercise5.Analyzer.Article;

internal interface IShortDescriptionTextAnalyser
{
    int? ResolveNumberOfUnits(string shortDescription);
}