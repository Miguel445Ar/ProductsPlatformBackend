using PruebaTecnica_Backend.Products.Domain.Models;
using PruebaTecnica_Backend.Products.Resources;

namespace PruebaTecnica_Backend.Orders.Resources
{
    public class OrderResource
    {
        public int Id { get; set; }
        public float TotalPrice { get; set; }
        public string DeliveryDate { get; set; }
        public int RequestedUnits { get; set; }
        public ProductResource Product { get; set; }
    }
}
