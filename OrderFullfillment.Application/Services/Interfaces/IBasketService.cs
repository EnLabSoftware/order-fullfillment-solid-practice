using System.Threading.Tasks;
using OrderFullfillment.Entity.Entities.Basket;

namespace OrderFullfillment.Application.Services.Interfaces
{
    public interface IBasketService
    {
        public Task<Basket> Get(int id);
        public Task<Basket> Create(int userId);
        public Task AddItem(int basketId, int productId);
        public Task RemoveItem(int basketId, int productId);
        public Task MarkAsResolved(int basketId);
    }
}