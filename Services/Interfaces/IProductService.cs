using System.Threading.Tasks;
using OrderFullfillment.Entities;

namespace OrderFullfillment.Services.Interfaces
{
    public interface IProductService
    {
        public Task<Product> Get(int id);
        public Task<Product> Create();
        public Task Add(Product product);
        public Task Remove(Product product);
    }
}