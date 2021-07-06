using System;
using System.Threading.Tasks;
using OrderFullfillment.Repositories;
using OrderFullfillment.SeedWorks;

namespace OderFullfillmentSolidPractice.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private AppDbContext _appDbContext;

        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Task<int> CommitAsync()
        {
            return _appDbContext.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed && disposing)
            {
                _appDbContext.Dispose();
            }
            disposed = true;
        }
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}