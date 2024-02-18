using Exercise5.Analyzer;
using Exercise5.Analyzer.Article;
using Exercise5.Controllers.Output;
using Exercise5.Test.Utils;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable IdentifierTypo
// ReSharper disable InconsistentNaming

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace Exercise5.Test.Analyzer.PricePerLitreAnalyserSpecs;

public abstract class PricePerLitreAnalyserSpec : Spec
{
    internal PricePerLitreAnalyser Sut = new();
}

[TestClass]
public class Wenn_aus_Artikeln_die_mit_dem_höchsten_und_niedrigsten_Preis_ermittelt_werden : PricePerLitreAnalyserSpec
{
    private readonly PricePerLitreResult _expectedResult = new(
        min: new PricePerLitre(1M,
        [
            new ResultArticle(productId: 4, articleId: 8)
        ]),
        max: new PricePerLitre(3M,
        [
            new ResultArticle(productId: 1, articleId: 5),
            new ResultArticle(productId: 2, articleId: 6)
        ])
    );

    private PricePerLitreResult _analyseResult;

    protected override void BecauseOf()
    {
        _analyseResult = Sut.GetMinMaxPricePerLiter(
        [
            new AnalysedArticle(productId: 1, articleId: 5, pricePerLiter: 3M, default, default),
            new AnalysedArticle(productId: 2, articleId: 6, pricePerLiter: 3M, default, default),
            new AnalysedArticle(productId: 3, articleId: 7, pricePerLiter: 2M, default, default),
            new AnalysedArticle(productId: 4, articleId: 8, pricePerLiter: 1M, default, default)
        ]);
    }

    [TestMethod]
    public void Sollen_im_Ergebnis_der_Preis_und_die_IDs_aller_betreffenden_Artikel_zurückgegeben_worden_sein()
    {
        _analyseResult.Should().BeEquivalentTo(_expectedResult);
    }
}

[TestClass]
public class Wenn_eine_leere_Artikelliste_analysiert_wird : PricePerLitreAnalyserSpec
{
    private readonly PricePerLitreResult _expectedResult = new(
        min: default,
        max: default
    );

    private PricePerLitreResult _analyseResult;

    protected override void BecauseOf()
    {
        _analyseResult = Sut.GetMinMaxPricePerLiter([]);
    }

    [TestMethod]
    public void Soll_ein_leeres_Ergebnis_ohne_Min_Max_Werte_zurückgegeben_worden_sein()
    {
        _analyseResult.Should().BeEquivalentTo(_expectedResult);
    }
}

[TestClass]
public class Wenn_in_der_Artikelliste_nur_Artikel_ohne_Literpreis_enthalten_sind : PricePerLitreAnalyserSpec
{
    private readonly PricePerLitreResult _expectedResult = new(
        min: default,
        max: default
    );

    private PricePerLitreResult _analyseResult;

    protected override void BecauseOf()
    {
        _analyseResult = Sut.GetMinMaxPricePerLiter(
            [
                new AnalysedArticle(productId: 1, articleId: 5, pricePerLiter: default, default, default),
                new AnalysedArticle(productId: 2, articleId: 6, pricePerLiter: default, default, default),
            ]
        );
    }

    [TestMethod]
    public void Soll_ein_leeres_Ergebnis_ohne_Min_Max_Werte_zurückgegeben_worden_sein()
    {
        _analyseResult.Should().BeEquivalentTo(_expectedResult);
    }
}

[TestClass]
public class Wenn_in_der_Artikelliste_nur_Artikel_mit_Preis_Null_enthalten_sind : PricePerLitreAnalyserSpec
{
    private readonly PricePerLitreResult _expectedResult = new(
        min: new PricePerLitre(0M,
        [
            new ResultArticle(productId: 1, articleId: 5),
            new ResultArticle(productId: 2, articleId: 6)
        ]),
        max: new PricePerLitre(0M,
        [
            new ResultArticle(productId: 1, articleId: 5),
            new ResultArticle(productId: 2, articleId: 6)
        ])
    );

    private PricePerLitreResult _analyseResult;

    protected override void BecauseOf()
    {
        _analyseResult = Sut.GetMinMaxPricePerLiter(
        [
            new AnalysedArticle(productId: 1, articleId: 5, pricePerLiter: 0M, default, default),
            new AnalysedArticle(productId: 2, articleId: 6, pricePerLiter: 0M, default, default),
        ]);
    }

    [TestMethod]
    public void Sollen_die_Artikel_im_Ergebnis_als_Min_und_Max_Artikel_zurückgegeben_worden_sein()
    {
        _analyseResult.Should().BeEquivalentTo(_expectedResult);
    }
}