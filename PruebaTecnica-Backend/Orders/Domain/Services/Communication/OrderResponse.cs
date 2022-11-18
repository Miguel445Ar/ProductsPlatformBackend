using PruebaTecnica_Backend.Orders.Domain.Models;
using PruebaTecnica_Backend.Shared.Domain.Services.Communication;

namespace PruebaTecnica_Backend.Orders.Domain.Services.Communication
{
    public class OrderResponse : BaseResponse<Order>
    {
        public OrderResponse(Order resource) : base(resource)
        {
        }

        public OrderResponse(string message) : base(message)
        {
        }
    }
}
