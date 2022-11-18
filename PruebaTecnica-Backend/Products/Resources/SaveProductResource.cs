using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica_Backend.Products.Resources
{
    public class SaveProductResource
    {
        [Required(ErrorMessage = "Code is required")]
        [MaxLength(20)]
        public string Code { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Stock is required")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "Unit Price is required")]
        public float UnitPrice { get; set; }
    }
}
