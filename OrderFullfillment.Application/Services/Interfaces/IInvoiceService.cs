using System.Threading.Tasks;
using OrderFullfillment.Entity.Entities.Orders;

namespace OrderFullfillment.Application.Services.Interfaces
{
    public interface IInvoiceService
    {
        public Task<int> CreateInvoice(Order order);
        public Task<string> Export(int orderId);
    }
}