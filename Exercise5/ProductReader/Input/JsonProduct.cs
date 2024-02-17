namespace Exercise5.ProductReader.Input
{
    public class JsonProduct
    {
        public long? Id { get; }
        public string? BrandName { get; }
        public string? Name { get; }
        public string? DescriptionText { get; }


        public JsonArticle[]? Articles { get; }


    }
}
