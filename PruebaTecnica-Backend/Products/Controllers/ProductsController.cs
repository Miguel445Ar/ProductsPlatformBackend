using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica_Backend.Products.Domain.Models;
using PruebaTecnica_Backend.Products.Domain.Services;
using PruebaTecnica_Backend.Products.Resources;
using PruebaTecnica_Backend.Shared.Extensions;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;

namespace PruebaTecnica_Backend.Products.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    [SwaggerTag("Create, Read And Update Products")]
    [Produces(MediaTypeNames.Application.Json)]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductResource>> GetProductsAsync()
        {
            var products = await _productService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(products);
            return resources;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productService.FindByIdAsync(id);
            var resource = _mapper.Map<Product, ProductResource>(product);
            return Ok(resource);
        }

        [HttpGet("[action]/{code}")]
        public async Task<IActionResult> GetProductByCode(string code)
        {
            var product = await _productService.FindByCodeAsync(code);
            var resource = _mapper.Map<Product, ProductResource>(product);
            return Ok(resource);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveProductResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var product = _mapper.Map<SaveProductResource,Product>(resource);
            var result = await _productService.SaveAsync(product);
            if(!result.Success)
                return BadRequest(result.Message);
            var productResource = _mapper.Map<Product, ProductResource>(result.Resource);
            return Ok(productResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveProductResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var product = _mapper.Map<SaveProductResource, Product>(resource);
            var result = await _productService.UpdateAsync(id, product);
            if (!result.Success)
                return BadRequest(result.Message);
            var productResource = _mapper.Map<Product, ProductResource>(result.Resource);
            return Ok(productResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _productService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var resource = _mapper.Map<Product, ProductResource>(result.Resource);
            return Ok(resource);
        }

    }
}
