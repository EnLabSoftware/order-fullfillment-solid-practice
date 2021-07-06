using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrderFullfillment.Entities;
using OrderFullfillment.Services.Interfaces;

namespace OrderFullfillment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BasketController : ControllerBase
    {
        private readonly ILogger<BasketController> _logger;
        private readonly IBasketService _basketService;

        public BasketController(ILogger<BasketController> logger, IBasketService basketService)
        {
            _logger = logger;
            _basketService = basketService;
        }

        [HttpGet("{id}")]
        public async Task<Basket> Get(int id)
        {
            _logger.LogInformation($"Getting order id {id}");
            return await _basketService.Get(id);
        }
    }
}