namespace Exercise5.Controllers.Output
{
    public class ExactPriceResult
    {
        public decimal Price { get; }
        public Article[] Articles { get; }

        public ExactPriceResult(decimal price, Article[] articles)
        {
            Price = price;
            Articles = articles;
        }
    }
}
