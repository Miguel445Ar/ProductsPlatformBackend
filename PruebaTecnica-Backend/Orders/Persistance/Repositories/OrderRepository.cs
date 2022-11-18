using Microsoft.EntityFrameworkCore;
using PruebaTecnica_Backend.Orders.Domain.Models;
using PruebaTecnica_Backend.Orders.Domain.Repositories;
using PruebaTecnica_Backend.Shared.Persistence.Contexts;
using PruebaTecnica_Backend.Shared.Persistence.Repositories;

namespace PruebaTecnica_Backend.Orders.Persistance.Repositories
{
    public class OrderRepository : BaseRepository, IOrderRepository
    {
        public OrderRepository(AppDbContext context): base(context)
        {

        }
        public async Task<Order> FindByIdAsync(int id)
        {
            return await _context.Orders.Include(o => o.Product).FirstAsync();
        }

        public async Task<IEnumerable<Order>> ListAsync()
        {
            return await _context.Orders.Include(o => o.Product).ToListAsync();
        }

        public void Remove(Order order)
        {
            _context.Remove(order);
        }

        public void Update(Order order)
        {
            _context.Update(order);
        }

        public async Task AddAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
        }
    }
}
