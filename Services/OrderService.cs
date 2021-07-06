using System.Threading.Tasks;
using OrderFullfillment.Entities;
using OrderFullfillment.SeedWorks;
using OrderFullfillment.Services.Interfaces;

namespace OrderFullfillment.Services
{
    public class OrderService : BaseService, IOrderService
    {
        private IRepository<Order> _repository;

        public OrderService(IUnitOfWork unitOfWork, IRepository<Order> repository) : base(unitOfWork)
        {
        }

        public async Task<Order> Get(int id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task CreateOrder(string customerName, string customerAddress, Basket basket)
        {
            var order = new Order(customerName, customerAddress);
            foreach (var item in basket.Products)
            {
                order.Products.Add(new OrderProductItem(item.Product, item.Product.Price, item.Quantity));
            }
            await UnitOfWork.CommitAsync();
        }

        public async Task UpdateStatus(int orderId, OrderStatus status)
        {
            var order = await _repository.GetAsync(orderId);
            order.Status = status;
            await UnitOfWork.CommitAsync();
        }
    }
}