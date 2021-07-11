using System.Threading.Tasks;

namespace OrderFullfillment.Infrastructure.SeedWorks
{
    public interface IRepository<T> where T : class   
    {   
        void Add(T entity);   
        void Delete(T entity);   
        void Update(T entity);
        Task<T> GetAsync(int id);
    }
}