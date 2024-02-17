using Exercise5.Analyzer.Article;
using Exercise5.Analyzer.NumberOfBottles;
using Exercise5.Controllers.Output;
using Exercise5.ProductReader;
using Microsoft.AspNetCore.Mvc;

namespace Exercise5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BeerAnalyser : ControllerBase
    {

        private readonly ILogger<BeerAnalyser> _logger;


        private IProductReader _productReader;
        private IArticleAnalyzer _articleAnalyzer;
        private INumberOfBottlesAnalyser _numberOfBottlesAnalyser;

        public BeerAnalyser(IProductReader productReader, ILogger<BeerAnalyser> logger)
        {
            _productReader = productReader;
            _logger = logger;
        }


        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<NumberOfBottlesResult> NumberOfBottles(string url)
        {
            var products = await _productReader.LoadProductsAsync(url);

            var articles = _articleAnalyzer.Analyse(products);

            return _numberOfBottlesAnalyser.GetMaxNumberOfBottlesArticles(articles);
        }

    }
}
