using Exercise5.Analyzer;
using Exercise5.Analyzer.Article;
using Exercise5.Controllers.Output;
using Exercise5.ProductReader;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Exercise5.Controllers;

[ApiController]
[Route("api/products/analysea")]
public class ExactPriceController(
    IProductReader productReader,
    IArticlesAnalyzer articlesAnalyzer,
    IExactPriceAnalyser exactPriceAnalyser)
    : ControllerBase
{
    private const string ExampleUrl = "https://flapotest.blob.core.windows.net/test/ProductData.json";

    [HttpGet(Name = "exactPrice")]
    public async Task<ExactPriceResult> ExactPrice([FromQuery, SwaggerParameter("descxxxription", Required = true)] string url)
    {
        var products = await productReader.LoadProductsAsync(url);

        var articles = articlesAnalyzer.Analyse(products);

        return exactPriceAnalyser.GetExactPriceItemsResult(articles, 17.99M);
    }
}