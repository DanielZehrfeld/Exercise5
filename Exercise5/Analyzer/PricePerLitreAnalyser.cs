﻿using Exercise5.Analyzer.Article;
using Exercise5.Analyzer.Extensions;
using Exercise5.Controllers.Output;
using NeverNull.Combinators;

namespace Exercise5.Analyzer;

internal class PricePerLitreAnalyser : IPricePerLitreAnalyser
{
    public PricePerLitreResult GetMinMaxPricePerLiter(IEnumerable<AnalysedArticle> articles)
    {
        var ordered = articles
            .Select(article => article.PricePerLiter.Select(articlePricePerLiter => (articlePricePerLiter, article)))
            .SelectValues()
            .GroupBy(article => article.articlePricePerLiter, article => article.article)
            .OrderBy(articleGroup => articleGroup.Key)
            .Select(articleGroup => (Price: articleGroup.Key, Items: articleGroup))
            .ToList();

        var minPrice = ordered.FirstOrDefault();
        var maxPrice = ordered.LastOrDefault();

        return minPrice != default && maxPrice != default
            ? new PricePerLitreResult(
                min: CreatePricePerLitreResult(minPrice.Price, minPrice.Items),
                max: CreatePricePerLitreResult(maxPrice.Price, maxPrice.Items))
            : new PricePerLitreResult(default, default);
    }

    private static PricePerLitre CreatePricePerLitreResult(decimal price, IEnumerable<AnalysedArticle> items)
        => new(price, items.Select(article => article.ToResultArticle()).ToArray());
}