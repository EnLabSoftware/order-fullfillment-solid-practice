using System.Threading.Tasks;
using OrderFullfillment.Application.ViewModels.Order;
using OrderFullfillment.Entity;
using OrderFullfillment.Entity.Entities.Order;

namespace OrderFullfillment.Application.Services.Interfaces
{
    public interface IOrderService
    {
        public Task<Order> Get(int id);
        public Task<Order> CreateOrder(OrderReqVM orderInfo);
        public Task UpdateStatus(int orderId, OrderStatus status);
    }
}