using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica_Backend.Products.Resources
{
    public class SaveProductResource
    {
        [Required]
        [MaxLength(20)]
        public string Code { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Stock { get; set; }

        [Required]
        public float UnitPrice { get; set; }
    }
}
