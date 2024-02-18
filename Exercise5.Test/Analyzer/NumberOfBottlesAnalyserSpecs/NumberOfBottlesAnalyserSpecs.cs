using Exercise5.Analyzer;
using Exercise5.Analyzer.Article;
using Exercise5.Controllers.Output;
using Exercise5.Test.Utils;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable IdentifierTypo
// ReSharper disable InconsistentNaming

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace Exercise5.Test.Analyzer.NumberOfBottlesAnalyserSpecs;

public abstract class NumberOfBottlesAnalyserSpec : Spec
{
    internal NumberOfBottlesAnalyser Sut = new();
}

[TestClass]
public class Wenn_aus_Artikeln_die_mit_den_meisten_NumberOfUnits_ermittelt_werden : NumberOfBottlesAnalyserSpec
{
    private readonly NumberOfBottlesResult _expectedResult = new(
        numberOfBottles: 5,
        articles: new[]
        {
            new ResultArticle(productId: 1, articleId: 5),
            new ResultArticle(productId: 3, articleId: 7)
        });

    private NumberOfBottlesResult _analyseResult;

    protected override void BecauseOf()
    {
        _analyseResult = Sut.GetMaxNumberOfBottlesArticles(
            new[]
            {
                new AnalysedArticle(productId: 1, articleId: 5, default, default, numberOfUnits: 5),
                new AnalysedArticle(productId: 2, articleId: 6, default, default, numberOfUnits: 3),
                new AnalysedArticle(productId: 3, articleId: 7, default, default, numberOfUnits: 5),
                new AnalysedArticle(productId: 4, articleId: 8, default, default, numberOfUnits: default)
            });
    }

    [TestMethod]
    public void Sollen_im_Ergebnis_die_Max_Zahl_und_die_IDs_aller_betreffenden_Artikel_zurückgegeben_worden_sein()
    {
        _analyseResult.Should().BeEquivalentTo(_expectedResult);
    }
}

[TestClass]
public class Wenn_eine_leere_Artikelliste_analysiert_wird : NumberOfBottlesAnalyserSpec
{
    private readonly NumberOfBottlesResult _expectedResult = new(
        numberOfBottles: 0,
        articles: Array.Empty<ResultArticle>());

    private NumberOfBottlesResult _analyseResult;

    protected override void BecauseOf()
    {
        _analyseResult = Sut.GetMaxNumberOfBottlesArticles(Array.Empty<AnalysedArticle>());
    }

    [TestMethod]
    public void Soll_eine_leere_Ergebnismenge_mit_Flaschenzahl_null_zurückgegeben_worden_sein()
    {
        _analyseResult.Should().BeEquivalentTo(_expectedResult);
    }
}

[TestClass]
public class Wenn_in_der_Artikelliste_nur_Artikel_ohne_Flaschenzahl_enthalten_sind : NumberOfBottlesAnalyserSpec
{
    private readonly NumberOfBottlesResult _expectedResult = new(
        numberOfBottles: 0,
        articles: Array.Empty<ResultArticle>());

    private NumberOfBottlesResult _analyseResult;

    protected override void BecauseOf()
    {
        _analyseResult = Sut.GetMaxNumberOfBottlesArticles(
            new[]
            {
                new AnalysedArticle(productId: 1, articleId: 5, default, default, numberOfUnits: default),
                new AnalysedArticle(productId: 2, articleId: 6, default, default, numberOfUnits: default)
            }
        );
    }

    [TestMethod]
    public void Soll_eine_leere_Ergebnismenge_mit_Flaschenzahl_null_zurückgegeben_worden_sein()
    {
        _analyseResult.Should().BeEquivalentTo(_expectedResult);
    }
}

[TestClass]
public class Wenn_in_der_Artikelliste_nur_Artikel_mit_Flaschnezahl_null_enthalten_sind : NumberOfBottlesAnalyserSpec
{
    private readonly NumberOfBottlesResult _expectedResult = new(
        numberOfBottles: 0,
        articles: new[]
        {
            new ResultArticle(productId: 1, articleId: 5),
            new ResultArticle(productId: 2, articleId: 6)
        });

    private NumberOfBottlesResult _analyseResult;

    protected override void BecauseOf()
    {
        _analyseResult = Sut.GetMaxNumberOfBottlesArticles(
            new[]
            {
                new AnalysedArticle(productId: 1, articleId: 5, default, default, numberOfUnits: 0),
                new AnalysedArticle(productId: 2, articleId: 6, default, default, numberOfUnits: 0)
            }
        );
    }

    [TestMethod]
    public void Sollen_auch_die_null_Artikel_ausgegeben_worden_sein()
    {
        _analyseResult.Should().BeEquivalentTo(_expectedResult);
    }
}