using PruebaTecnica_Backend.Orders.Domain.Models;

namespace PruebaTecnica_Backend.Orders.Domain.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> ListAsync();
        Task AddAsync(Order order);
        Task<Order> FindByIdAsync(int id);
        void Update(Order order);
        void Remove(Order order);
    }
}
