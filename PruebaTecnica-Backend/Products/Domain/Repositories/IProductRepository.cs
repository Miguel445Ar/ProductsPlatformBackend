using PruebaTecnica_Backend.Products.Domain.Models;

namespace PruebaTecnica_Backend.Products.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> ListAsync();
        Task AddAsync(Product product);
        Task<Product> FindByIdAsync(int id);
        Task<Product> FindByCodeAsync(string code);
        void Update(Product product);
        void Remove(Product product);
    }
}
