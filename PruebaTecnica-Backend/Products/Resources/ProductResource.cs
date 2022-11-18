namespace PruebaTecnica_Backend.Products.Resources
{
    public class ProductResource
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public float UnitPrice { get; set; }
    }
}
