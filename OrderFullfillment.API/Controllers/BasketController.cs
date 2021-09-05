using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrderFullfillment.Application.Services;
using OrderFullfillment.Application.Services.Interfaces;
using OrderFullfillment.Entity.Entities.Basket;

namespace OrderFullfillment.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BasketController : ControllerBase
    {
        private readonly ILogger<BasketController> _logger;
        private readonly BasketService _basketService;

        public BasketController(ILogger<BasketController> logger, BasketService basketService)
        {
            _logger = logger;
            _basketService = basketService;
        }

        [HttpGet("{id}")]
        public async Task<Basket> Get(int id)
        {
            _logger.LogInformation($"Getting basket id {id}");
            return await _basketService.Get(id);
        }
        
        [HttpPost]
        public async Task<Basket> Create(int userId)
        {
            _logger.LogInformation($"Create basket");
            return await _basketService.Create(userId);
        }
        
        [HttpPost("{id:int}/items")]
        public async Task AddItem(int id, int productId)
        {
            _logger.LogInformation($"Add item basket id {id}");
            await _basketService.AddItem(id, productId);
        }
        
        
        [HttpDelete("{id:int}/items/{itemId:int}")]
        public async Task RemoveItem(int id, int itemId)
        {
            _logger.LogInformation($"Remove basket item id {id}");
            await _basketService.RemoveItem(id, itemId);
        }
    }
}