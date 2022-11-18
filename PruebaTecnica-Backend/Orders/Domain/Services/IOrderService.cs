using PruebaTecnica_Backend.Orders.Domain.Models;
using PruebaTecnica_Backend.Orders.Domain.Services.Communication;

namespace PruebaTecnica_Backend.Orders.Domain.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> ListAsync();
        Task<Order> FindByIdAsync(int id);
        Task<OrderResponse> SaveAsync(Order order);
        Task<OrderResponse> UpdateAsync(int id,Order order);
        Task<OrderResponse> DeleteAsync(int id);
    }
}
