using Exercise5.ProductReader;
using Exercise5.Test.Utils;
using FakeItEasy;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable IdentifierTypo
// ReSharper disable InconsistentNaming

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace Exercise5.Test.ProductReader.ProductReaderSpecs;

public abstract class ProductReaderSpec : Spec
{
    protected const string UriToLoad = "UriToLoad";

    internal readonly IRestServiceDataReader RestServiceDataReader = A.Fake<IRestServiceDataReader>(opts => opts.Strict());

    internal IEnumerable<Article> ResultArticles;

    private Exercise5.ProductReader.ProductReader _sut;

    protected override void EstablishContext()
    {
        _sut = new Exercise5.ProductReader.ProductReader(RestServiceDataReader);
    }

    protected override void BecauseOf()
    {
        ResultArticles = _sut.LoadProductsAsync(UriToLoad).Result;
    }
}

[TestClass]
public class Wenn_valide_Testdaten_gelesen_werden : ProductReaderSpec
{
    private const string TestData = @"
[
  {
    ""id"": 1,
    ""brandName"": ""bn1"",
    ""name"": ""n1"",
    ""articles"": [
      {
        ""id"": 2,
        ""shortDescription"": ""sd2"",
        ""price"": 0.22,
        ""unit"": ""u2"",
        ""pricePerUnitText"": ""ppu2"",
        ""image"": ""i2""
      }
    ]
  },
  {
    ""id"": 3,
    ""brandName"": ""bn3"",
    ""name"": ""n3"",
    ""descriptionText"": ""d3"",
    ""articles"": [
      {
        ""id"": 4,
        ""shortDescription"": ""sd4"",
        ""price"": 44,
        ""unit"": ""u4"",
        ""pricePerUnitText"": ""ppu4"",
        ""image"": ""img4""
      },
	  {
        ""id"": 5,
        ""shortDescription"": ""sd5"",
        ""price"": 55.5,
        ""unit"": ""u5"",
        ""pricePerUnitText"": ""ppu5"",
        ""image"": ""img5""
      }
    ]
  }
]";

    private readonly Article[] _expected =
    {
        new(1, 2, 0.22M, "sd2", "ppu2"),
        new(3, 4, 44M, "sd4", "ppu4"),
        new(3, 5, 55.5M, "sd5", "ppu5"),
    };

    protected override void EstablishContext()
    {
        base.EstablishContext();

        A.CallTo(() => RestServiceDataReader.GetStringContentAsync(UriToLoad)).Returns(TestData);
    }

    [TestMethod]
    public void Sollen_die_Artikel_korrekt_ausgegeben_worden_sein()
    {
        ResultArticles.Should().BeEquivalentTo(_expected);
    }
}

[TestClass]
public class Wenn_leere_Testdaten_gelesen_werden : ProductReaderSpec
{
    private const string TestData = "";

    protected override void EstablishContext()
    {
        base.EstablishContext();

        A.CallTo(() => RestServiceDataReader.GetStringContentAsync(UriToLoad)).Returns(TestData);
    }

    [TestMethod]
    public void Sollen_keine_Artikel_ausgegeben_worden_sein()
    {
        ResultArticles.Should().BeEmpty();
    }
}

[TestClass]
public class Wenn_in_den_Testdaten_Produkten_Angaben_fehlen : ProductReaderSpec
{
    private const string TestData = @"
[
  {
     ""id"": 1,
    ""articles"": [
      {
         ""id"": 2
      }
    ]
  },
  {
     ""id"": 3,
    ""articles"": [
      {
         ""id"": 4
      },
	  {
         ""id"": 5
      }
    ]
  }
]";

    private readonly Article[] _expected =
    {
        new(1, 2, default, string.Empty, string.Empty),
        new(3, 4, default, string.Empty, string.Empty),
        new(3, 5, default, string.Empty, string.Empty),
    };

    protected override void EstablishContext()
    {
        base.EstablishContext();

        A.CallTo(() => RestServiceDataReader.GetStringContentAsync(UriToLoad)).Returns(TestData);
    }

    [TestMethod]
    public void Sollen_die_Artikel_ausgegeben_und_fehlende_Strings_durch_Leerstrings_ersetzt_worden_sein()
    {
        ResultArticles.Should().BeEquivalentTo(_expected);
    }
}

[TestClass]
public class Wenn_in_den_Testdaten_Produk_oder_Artikel_ID_fehlen : ProductReaderSpec
{
    private const string TestData = @"
[
  {
    ""articles"": [
      {
         ""id"": 2
      }
    ]
  },
  {
     ""id"": 3,
    ""articles"": [
      {
         ""id"": 4
      },
	  {
      }
    ]
  }
]";

    private readonly Article[] _expected =
    {
        new(3, 4, default, string.Empty, string.Empty)
    };

    protected override void EstablishContext()
    {
        base.EstablishContext();

        A.CallTo(() => RestServiceDataReader.GetStringContentAsync(UriToLoad)).Returns(TestData);
    }

    [TestMethod]
    public void Sollen_die_Artikel_mit_fehlenden_IDs_nicht_ausgegeben_worden_sein()
    {
        ResultArticles.Should().BeEquivalentTo(_expected);
    }
}