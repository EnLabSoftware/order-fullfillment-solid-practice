using System.Threading.Tasks;
using OrderFullfillment.Application.ViewModels.Order;
using OrderFullfillment.Entity.Entities.Orders;

namespace OrderFullfillment.Application.Services.Interfaces
{
    public interface IOrderService
    {
        public Task<Order> Get(int id);
        public Task<Order> CreateOrder(OrderRequestVM orderInfo);
        public Task MarkOrderAsPaid(int orderId);
    }
}