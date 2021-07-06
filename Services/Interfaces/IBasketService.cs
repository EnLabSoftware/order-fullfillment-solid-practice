using System.Threading.Tasks;
using OrderFullfillment.Entities;

namespace OrderFullfillment.Services.Interfaces
{
    public interface IBasketService
    {
        public Task<Basket> Get(int id);
        public Task<Basket> Create();
        public Task AddItem(int basketId, int productId);
        public Task RemoveItem(int basketId, int productId);
        public Task MarkedAsResolved(int basketId);
    }
}