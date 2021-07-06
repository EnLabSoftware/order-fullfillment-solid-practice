using System.Linq;
using System.Threading.Tasks;
using OrderFullfillment.Entities;
using OrderFullfillment.SeedWorks;
using OrderFullfillment.Services.Interfaces;

namespace OrderFullfillment.Services
{
    public class BasketService : BaseService, IBasketService
    {
        private readonly IRepository<Basket> _basketRepo;
        private readonly IRepository<Product> _productRepo;

        public BasketService(IUnitOfWork unitOfWork, IRepository<Basket> basketRepo, IRepository<Product> productRepo) : base(unitOfWork)
        {
            _basketRepo = basketRepo;
            _productRepo = productRepo;
        }

        public async Task<Basket> Get(int id)
        {
            return await _basketRepo.GetAsync(id);
        }

        public async Task<Basket> Create()
        {
            var basket = new Basket();
            _basketRepo.Add(basket);
            await UnitOfWork.CommitAsync();
            return basket;
        }

        public async Task AddItem(int basketId, int productId)
        {
            var basket = await _basketRepo.GetAsync(basketId);
            var productItem = basket.Products.FirstOrDefault(_ => _.Product.Id == productId);
            if (productItem == null)
            {
                var product = await _productRepo.GetAsync(productId);
                productItem = new BasketProductItem(product);
                basket.Products.Add(productItem);
            }
            else
            {
                productItem.Quantity += 1;
            }

            await UnitOfWork.CommitAsync();
        }

        public async Task RemoveItem(int basketId, int productId)
        {
            var basket = await _basketRepo.GetAsync(basketId);
            var productItem = basket.Products.FirstOrDefault(_ => _.Product.Id == productId);
            if (productItem != null)
            {
                basket.Products.Remove(productItem);
                await UnitOfWork.CommitAsync();
            }
        }

        public async Task MarkedAsResolved(int basketId)
        {
            var basket = await _basketRepo.GetAsync(basketId);
            basket.IsResolved = true;
            await UnitOfWork.CommitAsync();
        }
    }
}