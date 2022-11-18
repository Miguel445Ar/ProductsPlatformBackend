using Microsoft.EntityFrameworkCore;
using PruebaTecnica_Backend.Products.Domain.Models;
using PruebaTecnica_Backend.Products.Domain.Repositories;
using PruebaTecnica_Backend.Shared.Persistence.Contexts;
using PruebaTecnica_Backend.Shared.Persistence.Repositories;

namespace PruebaTecnica_Backend.Products.Persistence.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
        }

        public async Task<Product> FindByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> ListAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public void Remove(Product product)
        {
            _context.Remove(product);
        }

        public void Update(Product product)
        {
            _context.Update(product);
        }

        public async Task<Product> FindByCodeAsync(string code)
        {
            return await _context.Products
                .Where(p => p.Code == code).FirstAsync();
        }
    }
}
