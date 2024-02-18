using Exercise5.Analyzer;
using Exercise5.Analyzer.Article;
using Exercise5.Controllers.Output;
using Exercise5.ProductReader;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Exercise5.Controllers;

[ApiController]
[Route("api/products/analyse")]
public class AllResultsController(
    IProductReader productReader,
    IArticlesAnalyzer articlesAnalyzer,
    INumberOfBottlesAnalyser numberOfBottlesAnalyser,
    IExactPriceAnalyser exactPriceAnalyser,
    IPricePerLitreAnalyser pricePerLitreAnalyser)
    : ControllerBase
{
    private const string ExampleUrl = "https://flapotest.blob.core.windows.net/test/ProductData.json";

    [HttpGet(Name = "all")]
    public async Task<AllAnalyseResult> MaxNumberOfBottles([FromQuery, SwaggerParameter("descxxxription", Required = true)] string url)
    {
        var products = await productReader.LoadProductsAsync(url);

        var articles = articlesAnalyzer.Analyse(products);

        var exactPriceResult = exactPriceAnalyser.GetExactPriceItemsResult(articles, 
            
            //ToDo
            
            17.99M
            
            
            ); 
        var numberOfBottlesResult = numberOfBottlesAnalyser.GetMaxNumberOfBottlesArticles(articles);
        var pricePerLitreResult = pricePerLitreAnalyser.GetMinMaxPricePerLiter(articles);

        return new AllAnalyseResult(exactPriceResult, numberOfBottlesResult, pricePerLitreResult);
    }
}