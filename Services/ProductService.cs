using System.Threading.Tasks;
using OrderFullfillment.Entities;
using OrderFullfillment.SeedWorks;
using OrderFullfillment.Services.Interfaces;

namespace OrderFullfillment.Services
{
    public class ProductService : BaseService, IProductService
    {
        private IRepository<Basket> _repository;
        
        public ProductService(IUnitOfWork unitOfWork, IRepository<Order> repository) : base(unitOfWork)
        {
        }

        public Task<Product> Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Product> Create()
        {
            throw new System.NotImplementedException();
        }

        public Task Add(Product product)
        {
            throw new System.NotImplementedException();
        }

        public Task Remove(Product product)
        {
            throw new System.NotImplementedException();
        }
    }
}