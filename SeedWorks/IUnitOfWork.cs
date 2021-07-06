using System;
using System.Threading.Tasks;

namespace OrderFullfillment.SeedWorks
{
    public interface IUnitOfWork    
    {   
        Task<int> CommitAsync();   
		Task<TResult> ExecuteTransactionAsync<TResult>(Func<Task<TResult>> func);
    }  
}