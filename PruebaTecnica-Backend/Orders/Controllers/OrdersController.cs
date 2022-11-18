using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica_Backend.Orders.Domain.Models;
using PruebaTecnica_Backend.Orders.Domain.Services;
using PruebaTecnica_Backend.Orders.Domain.Services.Communication;
using PruebaTecnica_Backend.Orders.Resources;
using PruebaTecnica_Backend.Shared.Extensions;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;

namespace PruebaTecnica_Backend.Orders.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    [SwaggerTag("Create, Read And Update Orders")]
    [Produces(MediaTypeNames.Application.Json)]
    public class OrdersController: ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrdersController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<OrderResource>> GetOrdersAsync()
        {
            var orders = await _orderService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Order>, IEnumerable<OrderResource>>(orders);
            return resources;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var order = await _orderService.FindByIdAsync(id);
            var resource = _mapper.Map<Order, OrderResource>(order);
            return Ok(resource);

        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveOrderResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var order = _mapper.Map<SaveOrderResource, Order>(resource);
            var result = await _orderService.SaveAsync(order);
            if (!result.Success)
                return BadRequest(result.Message);
            var orderResource = _mapper.Map<Order, OrderResource>(result.Resource);
            return Ok(orderResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveOrderResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var order = _mapper.Map<SaveOrderResource, Order>(resource);
            var result = await _orderService.UpdateAsync(id, order);
            if (!result.Success)
                return BadRequest(result.Message);
            var orderResource = _mapper.Map<Order, OrderResource>(result.Resource);
            return Ok(orderResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _orderService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var resource = _mapper.Map<Order, OrderResource>(result.Resource);
            return Ok(resource);
        }
    }
}
