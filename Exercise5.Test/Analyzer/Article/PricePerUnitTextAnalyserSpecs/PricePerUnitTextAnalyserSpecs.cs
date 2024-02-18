using Exercise5.Analyzer.Article;
using Exercise5.Test.Utils;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable IdentifierTypo
// ReSharper disable InconsistentNaming

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace Exercise5.Test.Analyzer.Article.PricePerUnitTextAnalyserSpecs;

public abstract class PricePerUnitTextAnalyserSpec : Spec
{
    protected string _pricePerUnitString;
    private decimal? _parseResult;

    private readonly PricePerUnitTextAnalyser Sut = new();

    protected override void BecauseOf()
    {
        _parseResult = Sut.ResolvePricePerLiter(_pricePerUnitString);
    }

    protected void CheckResult(decimal? expected)
    {
        _parseResult.Should().Be(expected);
    }
}

[TestClass]
public class Wenn_ein_valider_PricePerUnit_String_geparsed_wird : PricePerUnitTextAnalyserSpec
{
    protected override void EstablishContext()
    {
        _pricePerUnitString = "(1,70 €/Liter)";
    }

    [TestMethod]
    public void Soll_der_Unitpreis_korrekt_ausgegeben_worden_sein() => CheckResult(expected: 1.7M);
}

[TestClass]
public class Wenn_ein_syntaktisch_richtiger_PricePerUnit_String_geparsed_wird : PricePerUnitTextAnalyserSpec
{
    protected override void EstablishContext()
    {
        _pricePerUnitString = "(0 €/Liter)";
    }

    [TestMethod]
    public void Soll_der_Unitpreis_korrekt_ausgegeben_worden_sein() => CheckResult(expected: 0);
}

[TestClass]
public class Wenn_ein_PricePerUnit_String_ohne_Werteangabe_geparsed_wird : PricePerUnitTextAnalyserSpec
{
    protected override void EstablishContext()
    {
        _pricePerUnitString = "(€/Liter)";
    }

    [TestMethod]
    public void Soll_kein_Unitpreis_ausgegeben_worden_sein() => CheckResult(expected: default);
}

[TestClass]
public class Wenn_ein_leerer_PricePerUnit_String_geparsed_wird : PricePerUnitTextAnalyserSpec
{
    protected override void EstablishContext()
    {
        _pricePerUnitString = string.Empty;
    }

    [TestMethod]
    public void Soll_kein_Unitpreis_ausgegeben_worden_sein() => CheckResult(expected: default);
}

[TestClass]
public class Wenn_ein_PricePerUnit_String_mit_abweichender_Unitangabe_geparsed_wird : PricePerUnitTextAnalyserSpec
{
    protected override void EstablishContext()
    {
        _pricePerUnitString = "(1,70 €/Galon)";
    }

    [TestMethod]
    public void Soll_kein_Unitpreis_ausgegeben_worden_sein() => CheckResult(expected: default);
}

[TestClass]
public class Wenn_ein_PricePerUnit_String_mit_abweichender_Währungsangabe_geparsed_wird : PricePerUnitTextAnalyserSpec
{
    protected override void EstablishContext()
    {
        _pricePerUnitString = "(1,70 L/Liter)";
    }

    [TestMethod]
    public void Soll_kein_Unitpreis_ausgegeben_worden_sein() => CheckResult(expected: default);
}

[TestClass]
public class Wenn_ein_PricePerUnit_String_mit_zusätzlichen_Klammern_und_Leerzeichen_geparsed_wird : PricePerUnitTextAnalyserSpec
{
    protected override void EstablishContext()
    {
        _pricePerUnitString = "( (1,70€/Liter)) )";
    }

    [TestMethod]
    public void Soll_der_Unitpreis_korrekt_ausgegeben_worden_sein() => CheckResult(expected: 1.7M);
}

[TestClass]
public class Wenn_ein_PricePerUnit_String_mit_fehlenden_Klammern_und_Leerzeichen_geparsed_wird : PricePerUnitTextAnalyserSpec
{
    protected override void EstablishContext()
    {
        _pricePerUnitString = "1,70€/Liter";
    }

    [TestMethod]
    public void Soll_der_Unitpreis_korrekt_ausgegeben_worden_sein() => CheckResult(expected: 1.7M);
}