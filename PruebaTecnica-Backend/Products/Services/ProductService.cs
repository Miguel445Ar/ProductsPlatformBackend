using PruebaTecnica_Backend.Products.Domain.Models;
using PruebaTecnica_Backend.Products.Domain.Repositories;
using PruebaTecnica_Backend.Products.Domain.Services;
using PruebaTecnica_Backend.Products.Domain.Services.Communication;
using PruebaTecnica_Backend.Shared.Domain.Repositories;

namespace PruebaTecnica_Backend.Products.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ProductResponse> DeleteAsync(int id)
        {
            var existingProduct = await _productRepository.FindByIdAsync(id);
            if (existingProduct == null)
                return new ProductResponse("Product not found");
            try
            {
                _productRepository.Remove(existingProduct);
                await _unitOfWork.CompleteAsync();
                return new ProductResponse(existingProduct);
            }
            catch (Exception e)
            {
                return new ProductResponse($"An error occurred while detecting the product: {e.Message}");
            }
        }

        public async Task<Product> FindByIdAsync(int id)
        {
            return await _productRepository.FindByIdAsync(id);
        }

        public async Task<IEnumerable<Product>> ListAsync()
        {
            return await _productRepository.ListAsync();
        }

        public async Task<ProductResponse> SaveAsync(Product product)
        {
            try
            {
                await _productRepository.AddAsync(product);
                await _unitOfWork.CompleteAsync();
                return new ProductResponse(product);
            }
            catch (Exception e)
            {
                return new ProductResponse($"An error occurred while saving the product: {e.Message} {e.InnerException?.Message}");
            }
        }

        public async Task<ProductResponse> UpdateAsync(int id, Product product)
        {
            var existingProduct = await _productRepository.FindByIdAsync(id);
            if (existingProduct == null)
                return new ProductResponse("Product not found");
            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Code = product.Code;
            existingProduct.Stock = product.Stock;
            existingProduct.UnitPrice = product.UnitPrice;

            try
            {
                _productRepository.Update(existingProduct);
                await _unitOfWork.CompleteAsync();
                return new ProductResponse(existingProduct);
            }
            catch (Exception e)
            {
                return new ProductResponse($"An error occurred while updating the product: {e.Message}");
            }
        }

        public async Task<Product> FindByCodeAsync(string code)
        {
            return await _productRepository.FindByCodeAsync(code);
        }
    }
}
