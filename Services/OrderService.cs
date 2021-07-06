using System.Threading.Tasks;
using OrderFullfillment.Entities;
using OrderFullfillment.SeedWorks;
using OrderFullfillment.Services.Interfaces;

namespace OrderFullfillment.Services
{
    public class OrderService : BaseService, IOrderService
    {
        private readonly IBasketService _basketService;

        private readonly IRepository<Order> _orderRepo;
        private readonly IRepository<Basket> _basketRepo;

        public OrderService(IUnitOfWork unitOfWork, IBasketService basketService, IRepository<Order> orderRepo, IRepository<Basket> basketRepo) : base(unitOfWork)
        {
            _orderRepo = orderRepo;
            _basketRepo = basketRepo;
            _basketService = basketService;
        }

        public async Task<Order> Get(int id)
        {
            return await _orderRepo.GetAsync(id);
        }

        public async Task CreateOrder(string customerName, string customerAddress, int basketId)
        {
            var order = new Order(customerName, customerAddress);
            var basket = await _basketRepo.GetAsync(basketId);
            foreach (var item in basket.Products)
            {
                order.Products.Add(new OrderProductItem(item.Product, item.Product.Price, item.Quantity));
            }
            
            await UnitOfWork.ExecuteTransactionAsync(async () =>
            {
                _orderRepo.Add(order);
                await _basketService.MarkedAsResolved(basketId);
                return await UnitOfWork.CommitAsync();
            });
        }

        public async Task UpdateStatus(int orderId, OrderStatus status)
        {
            var order = await _orderRepo.GetAsync(orderId);
            order.Status = status;
            await UnitOfWork.CommitAsync();
        }
    }
}