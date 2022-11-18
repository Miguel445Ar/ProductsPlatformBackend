using PruebaTecnica_Backend.Products.Domain.Models;
using PruebaTecnica_Backend.Products.Domain.Services.Communication;

namespace PruebaTecnica_Backend.Products.Domain.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> ListAsync();
        Task<Product> FindByIdAsync(int id);
        Task<Product> FindByCodeAsync(string code);
        Task<ProductResponse> SaveAsync(Product product);
        Task<ProductResponse> UpdateAsync(int id, Product product);
        Task<ProductResponse> DeleteAsync(int id);

    }
}
