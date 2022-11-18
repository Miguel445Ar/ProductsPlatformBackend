using PruebaTecnica_Backend.Products.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica_Backend.Orders.Resources
{
    public class SaveOrderResource
    {
        [Required(ErrorMessage = "Total Price is required")]
        public float TotalPrice { get; set; }
        [Required(ErrorMessage = "Delivery Date is required")]
        public string DeliveryDate { get; set; }
        [Required(ErrorMessage = "Requested Units are required")]
        public int RequestedUnits { get; set; }
        [Required(ErrorMessage = "Product Id is required")]
        public int ProductsId { get; set; }
    }
}
