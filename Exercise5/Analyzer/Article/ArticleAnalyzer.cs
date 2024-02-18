﻿using System.Globalization;
using System.Text.RegularExpressions;
using Exercise5.ProductReader;

namespace Exercise5.Analyzer.Article;

internal class ArticleAnalyzer : IArticleAnalyzer
{
    private readonly IPricePerUnitTextAnalyser _pricePerUnitTextAnalyser;
    private readonly IShortDescriptionTextAnalyser _shortDescriptionTextAnalyser;
        

    public ArticleAnalyzer(IPricePerUnitTextAnalyser pricePerUnitTextAnalyser, IShortDescriptionTextAnalyser shortDescriptionTextAnalyser)
    {
        _pricePerUnitTextAnalyser = pricePerUnitTextAnalyser;
        _shortDescriptionTextAnalyser = shortDescriptionTextAnalyser;
    }


    public IReadOnlyCollection<AnalysedArticle> Analyse(IEnumerable<ProductReader.Article> articles)
    {
        //ToDo undistinct product id / articleId 


        return articles.Select(AnalyseArticle).ToArray();
    }


    private AnalysedArticle AnalyseArticle(ProductReader.Article article)
    {

            

        /*
        "shortDescription": "24 x 0,33L (Glas)",
        "price": 28.99,
        "unit": "Liter",
        "PricePerUnitText": "(3,66 €/Liter)",
        */


        var pricePerLiter = _pricePerUnitTextAnalyser.ResolvePricePerLiter(article.ArticlePricePerUnitText);

        var numberOfUnits = _shortDescriptionTextAnalyser.ResolveNumberOfUnits(article.ArticleShortDescription);


        return new AnalysedArticle(article.ProductId,
            article.ArticleId,
            pricePerLiter.pricePerLiter,
            article.ArticlePrice,
            numberOfUnits.numberUfUnbits);
    }

       

  


}