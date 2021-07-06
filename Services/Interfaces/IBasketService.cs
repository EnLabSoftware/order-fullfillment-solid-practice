using System.Threading.Tasks;
using OrderFullfillment.Entities;

namespace OrderFullfillment.Services.Interfaces
{
    public interface IBasketService
    {
        public Task<Basket> Get(int id);
        public Task<Basket> Create();
        public Task Add(Product product);
        public Task Remove(Product product);
    }
}