namespace Exercise5.Controllers.Output
{
    public class NumberOfBottlesResult
    {
        //Todo json serializer attributes
        public int NumberOfBottles { get; }
        public Article[] Articles { get; }

        public NumberOfBottlesResult(int numberOfBottles, Article[] articles)
        {
            NumberOfBottles = numberOfBottles;
            Articles = articles;
        }
    }
}
