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

        public async Task Add(Order order)
        {
            _repository.Add(order);
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