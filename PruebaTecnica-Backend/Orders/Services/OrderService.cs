using PruebaTecnica_Backend.Orders.Domain.Models;
using PruebaTecnica_Backend.Orders.Domain.Repositories;
using PruebaTecnica_Backend.Orders.Domain.Services;
using PruebaTecnica_Backend.Orders.Domain.Services.Communication;
using PruebaTecnica_Backend.Products.Domain.Repositories;
using PruebaTecnica_Backend.Shared.Domain.Repositories;

namespace PruebaTecnica_Backend.Orders.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;

        public OrderService(IOrderRepository orderRepository, IUnitOfWork unitOfWork, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
        }

        public async Task<OrderResponse> DeleteAsync(int id)
        {
            var existingOrder = await _orderRepository.FindByIdAsync(id);
            if (existingOrder == null)
                return new OrderResponse("Order not found");
            try
            {
                _orderRepository.Remove(existingOrder);
                await _unitOfWork.CompleteAsync();
                return new OrderResponse(existingOrder);
            }catch(Exception e)
            {
                return new OrderResponse($"An error occurred while detecting the order: {e.Message}");
            }
        }

        public async Task<Order> FindByIdAsync(int id)
        {
            return await _orderRepository.FindByIdAsync(id);
        }

        public async Task<IEnumerable<Order>> ListAsync()
        {
            return await _orderRepository.ListAsync();
        }

        public async Task<OrderResponse> SaveAsync(Order order)
        {
            var existingProduct = await _productRepository.FindByIdAsync(order.ProductsId);
            if (existingProduct == null)
                return new OrderResponse("Product doesn't exists");
            order.Product = existingProduct;
            try
            {
                await _orderRepository.AddAsync(order);
                await _unitOfWork.CompleteAsync();
                return new OrderResponse(order);

            }catch(Exception e)
            {
                return new OrderResponse($"An error occurred while saving the order: {e.Message} {e.InnerException.Message}");
            }
        }

        async public Task<OrderResponse> UpdateAsync(int id, Order order)
        {
            var existingOrder = await _orderRepository.FindByIdAsync(id);
            var existingProduct = await _productRepository.FindByIdAsync(order.ProductsId);
            if (existingOrder == null)
                return new OrderResponse("Order not found");
            if (existingProduct == null)
                return new OrderResponse("Product not found");
            existingOrder.TotalPrice = order.TotalPrice;
            existingOrder.DeliveryDate = order.DeliveryDate;
            existingOrder.RequestedUnits = order.RequestedUnits;
            existingOrder.ProductsId = order.ProductsId;
            existingOrder.Product = existingProduct;
            try
            {
                _orderRepository.Update(existingOrder);
                await _unitOfWork.CompleteAsync();
                return new OrderResponse(existingOrder);
            }
            catch (Exception e)
            {
                return new OrderResponse($"An error ocurred while updating the order: {e.Message}");
            }
        }
    }
}
