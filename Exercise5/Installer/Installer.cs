using Exercise5.Analyzer.Article;
using Exercise5.Analyzer.NumberOfBottles;
using Exercise5.ProductReader;

namespace Exercise5.Installer;

internal static class Installer
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<IProductReader, ProductReader.ProductReader>();
        services.AddSingleton<IRestServiceDataReader, RestServiceDataReader>();
        services.AddSingleton<IArticleAnalyzer, ArticleAnalyzer>();
        services.AddSingleton<IPricePerUnitTextAnalyser, PricePerUnitTextAnalyser>();
        services.AddSingleton<IShortDescriptionTextAnalyser, ShortDescriptionTextAnalyser>();
        services.AddSingleton<INumberOfBottlesAnalyser, NumberOfBottlesAnalyser>();

        
    }
}