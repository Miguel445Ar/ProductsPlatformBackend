using PruebaTecnica_Backend.Products.Domain.Models;

namespace PruebaTecnica_Backend.ProductsPerOrders.Domain.Models
{
    public class ProductPerOrder
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int OrderId { get; set; }
        public Product Order { get; set; }
    }
}
