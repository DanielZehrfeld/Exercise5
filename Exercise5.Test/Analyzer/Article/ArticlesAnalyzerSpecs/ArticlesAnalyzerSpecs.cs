using Exercise5.Analyzer.Article;
using Exercise5.Test.Utils;
using FakeItEasy;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable IdentifierTypo
// ReSharper disable InconsistentNaming

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace Exercise5.Test.Analyzer.Article.ArticlesAnalyzerSpecs;

public abstract class ArticlesAnalyzerSpec : Spec
{
    internal IPricePerUnitTextAnalyser pricePerUnitTextAnalyser = A.Fake<IPricePerUnitTextAnalyser>(opts => opts.Strict());
    internal IShortDescriptionTextAnalyser shortDescriptionTextAnalyser = A.Fake<IShortDescriptionTextAnalyser>(opts => opts.Strict());

    internal ArticlesAnalyzer Sut;

    protected override void EstablishContext()
    {
        Sut = new ArticlesAnalyzer(pricePerUnitTextAnalyser, shortDescriptionTextAnalyser);
    }
}

[TestClass]
public class Wenn_valide_Artikel_analysiert_werden : ArticlesAnalyzerSpec
{
    private const long ProductId = 1;
    private const long ArticleId = 2;
    private const string ShortDescriptionTest = "33numberOfUnits";
    private const string PricePerUnitText = "2,2euroPerLtr";
    private const decimal Price = 12.3M;

    private const int ParsedNumberOfUnits = 33;
    private const decimal ParsedPricePerLiter = 2.2M;

    private IReadOnlyCollection<AnalysedArticle> _result;

    protected override void EstablishContext()
    {
        base.EstablishContext();

        A.CallTo(() => pricePerUnitTextAnalyser.ResolvePricePerLiter(PricePerUnitText)).Returns(ParsedPricePerLiter);
        A.CallTo(() => shortDescriptionTextAnalyser.ResolveNumberOfUnits(ShortDescriptionTest)).Returns(ParsedNumberOfUnits);
    }

    protected override void BecauseOf()
    {
        _result = Sut.Analyse(new[]
        {
            new Exercise5.ProductReader.Article(ProductId, ArticleId, Price, ShortDescriptionTest, PricePerUnitText),
        });
    }

    [TestMethod]
    public void Sollen_die_Ergebnisse_korrekt_zurückgegeben_worden_sein()
    {
        _result.Should()
            .BeEquivalentTo(new[]
            {
                new AnalysedArticle(
                    productId: ProductId,
                    articleId: ArticleId,
                    pricePerLiter: ParsedPricePerLiter,
                    totalPrice: Price,
                    numberOfUnits: ParsedNumberOfUnits)
            });
    }
}

[TestClass]
public class Wenn_Artikel_mit_fehlenden_Angaben_analysiert_werden : ArticlesAnalyzerSpec
{
    private IReadOnlyCollection<AnalysedArticle> _result;

    protected override void EstablishContext()
    {
        base.EstablishContext();

        A.CallTo(() => pricePerUnitTextAnalyser.ResolvePricePerLiter(A<string>._)).Returns(default);
        A.CallTo(() => shortDescriptionTextAnalyser.ResolveNumberOfUnits(A<string>._)).Returns(default);
    }

    protected override void BecauseOf()
    {
        _result = Sut.Analyse(new[]
        {
            new Exercise5.ProductReader.Article(3, 4, default, "desc", "ppu"),
        });
    }

    [TestMethod]
    public void Sollen_im_Ergebnis_leere_Felder_zurückgegeben_worden_sein()
    {
        _result.Should()
            .BeEquivalentTo(new[]
            {
                new AnalysedArticle(
                    productId: 3,
                    articleId: 4,
                    pricePerLiter: default,
                    totalPrice: default,
                    numberOfUnits: default)
            });
    }
}