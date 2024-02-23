using Exercise5.Analyzer.Article;
using Exercise5.Test.Utils;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NeverNull;

// ReSharper disable IdentifierTypo
// ReSharper disable InconsistentNaming

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace Exercise5.Test.Analyzer.Article.ShortDescriptionTextAnalyserSpecs;

public abstract class ShortDescriptionTextAnalyserSpec : Spec
{
    protected string _shortDescriptionString;
    private Option<int> _parseResult;

    private readonly ShortDescriptionTextAnalyser Sut = new();

    protected override void BecauseOf()
    {
        _parseResult = Sut.ResolveNumberOfUnits(_shortDescriptionString);
    }

    protected void CheckResult(Option<int> expected)
    {
        _parseResult.Should().Be(expected);
    }
}

[TestClass]
public class Wenn_ein_valider_ShortDescription_String_geparsed_wird : ShortDescriptionTextAnalyserSpec
{
    protected override void EstablishContext()
    {
        _shortDescriptionString = "20 x 0,33L (Glas)";
    }

    [TestMethod]
    public void Soll_die_Falschenzahl_korrekt_ausgegeben_worden_sein() => CheckResult(expected: 20);
}

[TestClass]
public class Wenn_ein_syntaktisch_richtiger_ShortDescription_String_geparsed_wird : ShortDescriptionTextAnalyserSpec
{
    protected override void EstablishContext()
    {
        _shortDescriptionString = "0x";
    }

    [TestMethod]
    public void Soll_die_Falschenzahl_korrekt_ausgegeben_worden_sein() => CheckResult(expected: 0);
}

[TestClass]
public class Wenn_ein_ShortDescription_String_ohne_Flaschentyp : ShortDescriptionTextAnalyserSpec
{
    protected override void EstablishContext()
    {
        _shortDescriptionString = "20 x";
    }

    [TestMethod]
    public void Soll_die_Falschenzahl_korrekt_ausgegeben_worden_sein() => CheckResult(expected: 20);
}

[TestClass]
public class Wenn_ein_ShortDescription_String_mit_validem_Zahlenwert_ohne_x_aber_mit_Leerzeichen_geparsed_wird : ShortDescriptionTextAnalyserSpec
{
    protected override void EstablishContext()
    {
        _shortDescriptionString = "  20  ";
    }

    [TestMethod]
    public void Soll_die_Falschenzahl_korrekt_ausgegeben_worden_sein() => CheckResult(expected: 20);
}

[TestClass]
public class Wenn_ein_leerer_ShortDescription_String_geparsed_wird : ShortDescriptionTextAnalyserSpec
{
    protected override void EstablishContext()
    {
        _shortDescriptionString = string.Empty;
    }

    [TestMethod]
    public void Soll_keine_Falschenzahl_ausgegeben_worden_sein() => CheckResult(expected: default);
}

[TestClass]
public class Wenn_ein_ShortDescription_String_ohne_Zahlenangabe_geparsed_wird : ShortDescriptionTextAnalyserSpec
{
    protected override void EstablishContext()
    {
        _shortDescriptionString = "test x test";
    }

    [TestMethod]
    public void Soll_keine_Falschenzahl_ausgegeben_worden_sein() => CheckResult(expected: default);
}

[TestClass]
public class Wenn_ein_ShortDescription_String_mit_abweichender_Flaschenangabe_geparsed_wird : ShortDescriptionTextAnalyserSpec
{
    protected override void EstablishContext()
    {
        _shortDescriptionString = "\"20 x 0.3Irgendwas_anderes3L\"";
    }

    [TestMethod]
    public void Soll_keine_Falschenzahl_ausgegeben_worden_sein() => CheckResult(expected: default);
}

[TestClass]
public class Wenn_ein_ShortDescription_String_mit_dezimaler_Zahl_geparsed_wird : ShortDescriptionTextAnalyserSpec
{
    protected override void EstablishContext()
    {
        _shortDescriptionString = "20,5 x 0,33L (Glas)";
    }

    [TestMethod]
    public void Soll_keine_Falschenzahl_ausgegeben_worden_sein() => CheckResult(expected: default);
}

[TestClass]
public class Wenn_ein_ShortDescription_String_mit_zusätzlichen_Klammern_und_Leerzeichen_geparsed_wird : ShortDescriptionTextAnalyserSpec
{
    protected override void EstablishContext()
    {
        _shortDescriptionString = "((20 x 0,33L (Glas)";
    }

    [TestMethod]
    public void Soll_keine_Falschenzahl_ausgegeben_worden_sein() => CheckResult(expected: default);
}