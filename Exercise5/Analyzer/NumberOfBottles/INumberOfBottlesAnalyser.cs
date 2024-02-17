﻿using Exercise5.Analyzer.Article;
using Exercise5.Controllers.Output;

namespace Exercise5.Analyzer.NumberOfBottles;

public interface INumberOfBottlesAnalyser
{
    NumberOfBottlesResult GetMaxNumberOfBottlesArticles(IReadOnlyCollection<AnalysedArticle> articles);
}