using System;
using System.Threading.Tasks;

namespace OrderFullfillment.Infrastructure.SeedWorks
{
    public interface IUnitOfWork    
    {   
        Task<int> SaveChangeAsync();   
		Task<TResult> ExecuteTransactionAsync<TResult>(Func<Task<TResult>> func);
    }  
}