﻿using Exercise5.Analyzer;
using Exercise5.Analyzer.Article;
using Exercise5.Controllers.Output;
using Exercise5.ProductReader;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Exercise5.Controllers;

[ApiController]
[Route("api/products/analyseb")]
public class NumberOfBottlesController(
    IProductReader productReader,
    IArticlesAnalyzer articlesAnalyzer,
    INumberOfBottlesAnalyser numberOfBottlesAnalyser)
    : ControllerBase
{
    private const string ExampleUrl = "https://flapotest.blob.core.windows.net/test/ProductData.json";

    [HttpGet(Name = "maxNumberOfBottles")]
    public async Task<NumberOfBottlesResult> MaxNumberOfBottles([FromQuery, SwaggerParameter("descxxxription", Required = true)] string url)
    {
        var products = await productReader.LoadProductsAsync(url);

        var articles = articlesAnalyzer.Analyse(products);

        return numberOfBottlesAnalyser.GetMaxNumberOfBottlesArticles(articles);
    }
}