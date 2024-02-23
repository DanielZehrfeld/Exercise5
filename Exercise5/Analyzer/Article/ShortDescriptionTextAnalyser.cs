using NeverNull;

namespace Exercise5.Analyzer.Article;

internal class ShortDescriptionTextAnalyser : IShortDescriptionTextAnalyser
{
    public Option<int> ResolveNumberOfUnits(string shortDescription)
    {
        var unitCountResult = Option<int>.None;

        var positionOfX = shortDescription.IndexOf('x');

        var stringToParse = positionOfX > 0
            ? shortDescription[..positionOfX]
            : shortDescription;

        if (int.TryParse(stringToParse, out var parseResult))
        {
            unitCountResult = parseResult;
        }

        return unitCountResult;
    }
}