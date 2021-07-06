using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrderFullfillment.Entities;
using OrderFullfillment.Services.Interfaces;

namespace OrderFullfillment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderService _orderService;

        public OrderController(ILogger<OrderController> logger, IOrderService orderService)
        {
            _logger = logger;
            _orderService = orderService;
        }

        [HttpGet("{id}")]
        public async Task<Order> Get(int id)
        {
            _logger.LogInformation($"Getting order id {id}");
            return await _orderService.Get(id);
        }
    }
}