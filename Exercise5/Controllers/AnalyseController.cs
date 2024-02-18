using Exercise5.Analyzer;
using Exercise5.Analyzer.Article;
using Exercise5.Controllers.Output;
using Exercise5.ProductReader;
using Microsoft.AspNetCore.Mvc;

namespace Exercise5.Controllers;

[ApiController]
[Route("api/products/[controller]")]
public class AnalyseController(
    IProductReader productReader,
    IArticlesAnalyzer articlesAnalyzer,
    INumberOfBottlesAnalyser numberOfBottlesAnalyser,
    IExactPriceAnalyser exactPriceAnalyser,
    IPricePerLitreAnalyser pricePerLitreAnalyser)
    : ControllerBase
{
    private const string ExampleUrl = "https://flapotest.blob.core.windows.net/test/ProductData.json";
    private const decimal DefaultExactPrice = 17.99M;

    [HttpGet]
    public async Task<AllAnalyseResult> All([FromQuery] string url = ExampleUrl)
    {
        var articles = await LoadAndAnalyzeArticles(url);

        var exactPriceResult = exactPriceAnalyser.GetExactPriceItemsResult(articles, DefaultExactPrice);
        var numberOfBottlesResult = numberOfBottlesAnalyser.GetMaxNumberOfBottlesArticles(articles);
        var pricePerLitreResult = pricePerLitreAnalyser.GetMinMaxPricePerLiter(articles);

        return new AllAnalyseResult(exactPriceResult, numberOfBottlesResult, pricePerLitreResult);
    }

    [HttpGet("exactPrice")]
    [HttpGet("exactPrice/{price:decimal?}")]
    public async Task<ExactPriceResult> ExactPrice([FromQuery] string url = ExampleUrl, [FromRoute] decimal price = DefaultExactPrice)
    {
        var articles = await LoadAndAnalyzeArticles(url);

        return exactPriceAnalyser.GetExactPriceItemsResult(articles, price);
    }

    [HttpGet("maxNumberOfBottles")]
    public async Task<NumberOfBottlesResult> MaxNumberOfBottles([FromQuery] string url = ExampleUrl)
    {
        var articles = await LoadAndAnalyzeArticles(url);

        return numberOfBottlesAnalyser.GetMaxNumberOfBottlesArticles(articles);
    }

    [HttpGet("minMaxPricePerLitre")]
    public async Task<PricePerLitreResult> MinMaxPricePerLitre([FromQuery] string url = ExampleUrl)
    {
        var articles = await LoadAndAnalyzeArticles(url);

        return pricePerLitreAnalyser.GetMinMaxPricePerLiter(articles);
    }

    private async Task<IReadOnlyCollection<AnalysedArticle>> LoadAndAnalyzeArticles(string url)
    {
        var products = await productReader.LoadProductsAsync(url);

        return articlesAnalyzer.Analyse(products);
    }
}