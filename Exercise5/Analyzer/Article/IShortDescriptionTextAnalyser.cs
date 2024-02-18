namespace Exercise5.Analyzer.Article;

internal interface IShortDescriptionTextAnalyser
{
    (int numberUfUnbits, bool hasError) ResolveNumberOfUnits(string shortDescription);
}