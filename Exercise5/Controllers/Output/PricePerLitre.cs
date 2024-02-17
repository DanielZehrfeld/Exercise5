namespace Exercise5.Controllers.Output
{
    public class PricePerLitre
    {
        public decimal PricePerLitre { get; }
        public Article Article { get; }

        public PricePerLitre(decimal pricePerLitre, Article article)
        {
            PricePerLitre = pricePerLitre;
            Article = article;
        }
    }
}
