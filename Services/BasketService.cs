using System.Threading.Tasks;
using OrderFullfillment.Entities;
using OrderFullfillment.SeedWorks;
using OrderFullfillment.Services.Interfaces;

namespace OrderFullfillment.Services
{
    public class BasketService : BaseService, IBasketService
    {
        private IRepository<Basket> _repository;
        
        public BasketService(IUnitOfWork unitOfWork, IRepository<Order> repository) : base(unitOfWork)
        {
        }

        public Task<Basket> Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Basket> Create()
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