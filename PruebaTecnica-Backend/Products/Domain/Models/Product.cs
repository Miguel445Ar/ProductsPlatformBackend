using PruebaTecnica_Backend.Orders.Domain.Models;

namespace PruebaTecnica_Backend.Products.Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public float UnitPrice { get; set; }
        public IList<Order> Orders { get; set; } = new List<Order>();
    }
}
