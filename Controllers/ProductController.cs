using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrderFullfillment.Entities;
using OrderFullfillment.Services.Interfaces;

namespace OrderFullfillment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;

        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpGet("{id}")]
        public async Task<Product> Get(int id)
        {
            _logger.LogInformation($"Getting order id {id}");
            return await _productService.Get(id);
        }
    }
}