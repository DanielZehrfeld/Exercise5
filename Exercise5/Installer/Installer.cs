using Exercise5.Analyzer;
using Exercise5.Analyzer.Article;
using Exercise5.ProductReader;

namespace Exercise5.Installer;

internal static class Installer
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<IProductReader, ProductReader.ProductReader>();
        services.AddSingleton<IRestServiceDataReader, RestServiceDataReader>();
        services.AddSingleton<IArticlesAnalyzer, ArticlesAnalyzer>();
        services.AddSingleton<IPricePerUnitTextAnalyser, PricePerUnitTextAnalyser>();
        services.AddSingleton<IShortDescriptionTextAnalyser, ShortDescriptionTextAnalyser>();
        services.AddSingleton<INumberOfBottlesAnalyser, NumberOfBottlesAnalyser>();
        services.AddSingleton<IExactPriceAnalyser, ExactPriceAnalyser>();
        services.AddSingleton<IPricePerLitreAnalyser, PricePerLitreAnalyser>();
    }
}