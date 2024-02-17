namespace Exercise5.Controllers.Output
{
    public class PricePerLitreResult
    {
        public PricePerLitre Max { get; }
        public PricePerLitre Min { get; }

        public PricePerLitreResult(PricePerLitre max, PricePerLitre min)
        {
            Max = max;
            Min = min;
        }
    }
}
