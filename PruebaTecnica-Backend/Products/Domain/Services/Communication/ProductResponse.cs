using PruebaTecnica_Backend.Products.Domain.Models;
using PruebaTecnica_Backend.Shared.Domain.Services.Communication;

namespace PruebaTecnica_Backend.Products.Domain.Services.Communication
{
    public class ProductResponse: BaseResponse<Product>
    {
        public ProductResponse(Product resource) : base(resource)
        {
        }
        public ProductResponse(string message) : base(message)
        {
        }
    }
}
