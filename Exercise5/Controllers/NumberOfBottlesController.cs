using Exercise5.Analyzer;
using Exercise5.Analyzer.Article;
using Exercise5.Controllers.Output;
using Exercise5.ProductReader;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Exercise5.Controllers;

[ApiController]
[Route("api/products/analyse")]
public class NumberOfBottlesController : ControllerBase
{
    private const string ExampleUrl = "https://flapotest.blob.core.windows.net/test/ProductData.json";

    private readonly IProductReader _productReader;
    private readonly IArticlesAnalyzer _articlesAnalyzer;
    private readonly INumberOfBottlesAnalyser _numberOfBottlesAnalyser;

    internal NumberOfBottlesController(IProductReader productReader,
        IArticlesAnalyzer articlesAnalyzer,
        INumberOfBottlesAnalyser numberOfBottlesAnalyser)
    {
        _productReader = productReader;
        _articlesAnalyzer = articlesAnalyzer;
        _numberOfBottlesAnalyser = numberOfBottlesAnalyser;
    }

    [HttpGet(Name = "maxNumberOfBottles")]
    public async Task<NumberOfBottlesResult> MaxNumberOfBottles([SwaggerParameter("description", Required = true)] string url)
    {
        var products = await _productReader.LoadProductsAsync(url);

        var articles = _articlesAnalyzer.Analyse(products);

        return _numberOfBottlesAnalyser.GetMaxNumberOfBottlesArticles(articles);
    }
}