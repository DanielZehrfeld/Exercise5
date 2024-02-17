namespace Exercise5.Analyzer.Article;

public interface IShortDescriptionTextAnalyser
{
    (int numberUfUnbits, bool hasError) ResolveNumberOfUnits(string shortDescription);
}