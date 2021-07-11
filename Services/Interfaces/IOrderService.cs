using System.Threading.Tasks;
using OrderFullfillment.Entities;
using OrderFullfillment.Entities.Order;
using OrderFullfillment.ViewModels;
using OrderFullfillment.ViewModels.Order;

namespace OrderFullfillment.Services.Interfaces
{
    public interface IOrderService
    {
        public Task<Order> Get(int id);
        public Task<Order> CreateOrder(OrderReqVM orderInfo);
        public Task UpdateStatus(int orderId, OrderStatus status);
    }
}