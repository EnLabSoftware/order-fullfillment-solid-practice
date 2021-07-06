using System.Threading.Tasks;
using OrderFullfillment.Repositories;
using OrderFullfillment.SeedWorks;

namespace OderFullfillmentSolidPractice.Repositories
{
    public class UnitOfWork  : IUnitOfWork    
    {   
        private AppDbContext _appDbContext;   
   
        public UnitOfWork (AppDbContext appDbContext)   
        {   
            _appDbContext = appDbContext;   
        }   
   
        public Task<int> CommitAsync()   
        {   
            return _appDbContext.SaveChangesAsync();   
        }   
    }
}