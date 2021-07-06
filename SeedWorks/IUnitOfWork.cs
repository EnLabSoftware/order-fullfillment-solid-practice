using System.Threading.Tasks;

namespace OrderFullfillment.SeedWorks
{
    public interface IUnitOfWork    
    {   
        Task<int> CommitAsync();   
    }  
}