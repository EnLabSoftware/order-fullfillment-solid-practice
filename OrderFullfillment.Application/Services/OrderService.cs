using System.Threading.Tasks;
using OrderFullfillment.Application.SeedWorks;
using OrderFullfillment.Application.Services.Interfaces;
using OrderFullfillment.Application.ViewModels.Order;
using OrderFullfillment.Entity;
using OrderFullfillment.Entity.Entities.Basket;
using OrderFullfillment.Entity.Entities.Order;
using OrderFullfillment.Infrastructure.SeedWorks;

namespace OrderFullfillment.Application.Services
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

        public async Task<Order> CreateOrder(OrderReqVM orderInfo)
        {
            var order = new Order(orderInfo.CustomerName, orderInfo.Address);
            var basket = await _basketRepo.GetAsync(orderInfo.BasketId);
            foreach (var item in basket.Products)
            {
                order.Products.Add(new OrderProductItem(item.Product, item.Product.Price, item.Quantity));
            }
            
            await UnitOfWork.ExecuteTransactionAsync(async () =>
            {
                _orderRepo.Add(order);
                await _basketService.MarkedAsResolved(orderInfo.BasketId);
                return await UnitOfWork.CommitAsync();
            });
            return order;
        }

        public async Task UpdateStatus(int orderId, OrderStatus status)
        {
            var order = await _orderRepo.GetAsync(orderId);
            order.Status = status;
            await UnitOfWork.CommitAsync();
        }
    }
}