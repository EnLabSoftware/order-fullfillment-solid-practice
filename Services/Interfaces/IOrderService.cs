using System.Threading.Tasks;
using OrderFullfillment.Entities;

namespace OrderFullfillment.Services.Interfaces
{
    public interface IOrderService
    {
        public Task<Order> Get(int id);
        public Task Add(Order order);
        public Task UpdateStatus(int orderId, OrderStatus status);
    }
}