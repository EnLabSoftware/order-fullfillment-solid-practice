using System.Threading.Tasks;
using OrderFullfillment.Application.SeedWorks;
using OrderFullfillment.Application.Services.Interfaces;
using OrderFullfillment.Entity.Entities;
using OrderFullfillment.Infrastructure.SeedWorks;

namespace OrderFullfillment.Application.Services
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IRepository<Product> _repository;
        
        public ProductService(IUnitOfWork unitOfWork, IRepository<Product> repository) : base(unitOfWork)
        {
            _repository = repository;
        }

        public async Task<Product> Get(int id)
        {
            return await _repository.GetAsync(id);
        }
        
        public async Task<Product> Add(Product product)
        {
            _repository.Add(product);
            await UnitOfWork.CommitAsync();
            return product;
        }
        
        public async Task Remove(int id)
        {
            var product = await _repository.GetAsync(id);
            if (product != null)
            {
                _repository.Delete(product);
                await UnitOfWork.CommitAsync();
            }
        }
    }
}