using Exercise5.Analyzer.Article;
using Exercise5.Analyzer.NumberOfBottles;
using Exercise5.Controllers.Output;
using Exercise5.ProductReader;
using Microsoft.AspNetCore.Mvc;

namespace Exercise5.Controllers;

[ApiController]
[Route("api/products/analyse")]
public class NumberOfBottlesController : ControllerBase
{
    private readonly IProductReader _productReader;
    private readonly IArticleAnalyzer _articleAnalyzer;
    private readonly INumberOfBottlesAnalyser _numberOfBottlesAnalyser;

    public NumberOfBottlesController(IProductReader productReader,
        IArticleAnalyzer articleAnalyzer,
        INumberOfBottlesAnalyser numberOfBottlesAnalyser)
    {
        _productReader = productReader;
        _articleAnalyzer = articleAnalyzer;
        _numberOfBottlesAnalyser = numberOfBottlesAnalyser;
    }

    [HttpGet(Name = "maxNumberOfBottles")]
    public async Task<NumberOfBottlesResult> MaxNumberOfBottles(string url)
    {
        var products = await _productReader.LoadProductsAsync(url);

        var articles = _articleAnalyzer.Analyse(products);

        return _numberOfBottlesAnalyser.GetMaxNumberOfBottlesArticles(articles);
    }
}