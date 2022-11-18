using PruebaTecnica_Backend.Products.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace PruebaTecnica_Backend.Orders.Domain.Models
{
    public class Order
    {
        public int Id { get; set; }
        public float TotalPrice { get; set; }
        public string DeliveryDate { get; set; }
        public int RequestedUnits { get; set; }
        public int ProductsId { get; set; }
        public Product Product { get; set; }
    }
}
