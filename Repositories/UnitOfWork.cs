using System;
using System.Threading.Tasks;
using OrderFullfillment.SeedWorks;

namespace OrderFullfillment.Repositories
{
    public sealed class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDbContext _appDbContext;

        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Task<int> CommitAsync()
        {
            return _appDbContext.SaveChangesAsync();
        }

        private bool _disposed = false;

        private void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _appDbContext.Dispose();
            }
            _disposed = true;
        }
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}