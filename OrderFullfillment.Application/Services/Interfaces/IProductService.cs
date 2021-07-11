using System.Threading.Tasks;
using OrderFullfillment.Entity.Entities;

namespace OrderFullfillment.Application.Services.Interfaces
{
    public interface IProductService
    {
        public Task<Product> Get(int id);
        public Task<Product> Add(Product product);
        public Task Remove(int id);
    }
}