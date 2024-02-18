using Exercise5.Analyzer;
using Exercise5.Analyzer.Article;
using Exercise5.Controllers.Output;
using Exercise5.Test.Utils;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable IdentifierTypo
// ReSharper disable InconsistentNaming

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace Exercise5.Test.Analyzer.ExactPriceAnalyserSpecs;

public abstract class ExactPriceAnalyserSpec : Spec
{
    protected const decimal TotalPrice = 12.3M;

    internal ExactPriceAnalyser Sut = new();
}

[TestClass]
public class Wenn_aus_Artikeln_die_mit_exaktem_Preis_ermittelt_werden : ExactPriceAnalyserSpec
{
    private readonly ExactPriceResult _expectedResult = new(
        price: TotalPrice,
        articles:
        [
            new ResultArticle(productId: 1, articleId: 5),
            new ResultArticle(productId: 3, articleId: 7)
        ]);

    private ExactPriceResult _analyseResult;

    protected override void BecauseOf()
    {
        _analyseResult = Sut.GetExactPriceItemsResult(
            [
                new AnalysedArticle(productId: 1, articleId: 5, default, totalPrice: TotalPrice, default),
                new AnalysedArticle(productId: 2, articleId: 6, default, totalPrice: default, default),
                new AnalysedArticle(productId: 3, articleId: 7, default, totalPrice: TotalPrice, default),
                new AnalysedArticle(productId: 4, articleId: 8, default, totalPrice: 22M, default)
            ],
            TotalPrice
        );
    }

    [TestMethod]
    public void Sollen_im_Ergebnis_der_gesuchte_Preis_und_die_IDs_aller_betreffenden_Artikel_zurückgegeben_worden_sein()
    {
        _analyseResult.Should().BeEquivalentTo(_expectedResult);
    }
}

[TestClass]
public class Wenn_eine_leere_Artikelliste_analysiert_wird : ExactPriceAnalyserSpec
{
    private readonly ExactPriceResult _expectedResult = new(
        price: TotalPrice,
        articles: []);

    private ExactPriceResult _analyseResult;

    protected override void BecauseOf()
    {
        _analyseResult = Sut.GetExactPriceItemsResult(Array.Empty<AnalysedArticle>(), TotalPrice);
    }

    [TestMethod]
    public void Soll_eine_leere_Ergebnismenge_mit_für_den_gesuchten_Preis_zurückgegeben_worden_sein()
    {
        _analyseResult.Should().BeEquivalentTo(_expectedResult);
    }
}

[TestClass]
public class Wenn_in_der_Artikelliste_nur_Artikel_ohne_Preisangabe_enthalten_sind : ExactPriceAnalyserSpec
{
    private readonly ExactPriceResult _expectedResult = new(
        price: TotalPrice,
        articles: []);

    private ExactPriceResult _analyseResult;

    protected override void BecauseOf()
    {
        _analyseResult = Sut.GetExactPriceItemsResult(
            [
                new AnalysedArticle(productId: 1, articleId: 5, default, totalPrice: default, default),
                new AnalysedArticle(productId: 2, articleId: 6, default, totalPrice: default, default)
            ],
            TotalPrice
        );
    }

    [TestMethod]
    public void Soll_eine_leere_Ergebnismenge_mit_Flaschenzahl_null_zurückgegeben_worden_sein()
    {
        _analyseResult.Should().BeEquivalentTo(_expectedResult);
    }
}

[TestClass]
public class Wenn_in_der_Artikelliste_nur_abweichender_Preisangabe_enthalten_sind : ExactPriceAnalyserSpec
{
    private readonly ExactPriceResult _expectedResult = new(
        price: TotalPrice,
        articles: []);

    private ExactPriceResult _analyseResult;

    protected override void BecauseOf()
    {
        _analyseResult = Sut.GetExactPriceItemsResult(
            [
                new AnalysedArticle(productId: 1, articleId: 5, default, totalPrice: 44M, default),
                new AnalysedArticle(productId: 2, articleId: 6, default, totalPrice: default, default)
            ],
            TotalPrice
        );
    }

    [TestMethod]
    public void Soll_eine_leere_Ergebnismenge_mit_Flaschenzahl_null_zurückgegeben_worden_sein()
    {
        _analyseResult.Should().BeEquivalentTo(_expectedResult);
    }
}