using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderFullfillment.Infrastructure.SeedWorks;

namespace OrderFullfillment.Infrastructure
{
    public sealed class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDbContext _appDbContext;

        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Task<int> SaveChangeAsync()
        {
            return _appDbContext.SaveChangesAsync();
        }
        
        public async Task<TResult> ExecuteTransactionAsync<TResult>(Func<Task<TResult>> func)
        {
            var strategy = _appDbContext.Database.CreateExecutionStrategy();
            var transResult = await strategy.ExecuteAsync(async () =>
            {
                using (var trans = await _appDbContext.Database.BeginTransactionAsync())
                {
                    try
                    {
                        var result = await func.Invoke();
                        await trans.CommitAsync();
                        return result;
                    }
                    catch (Exception)
                    {
                        await trans.RollbackAsync();
                        throw;
                    }
                }
            });
            return transResult;
        }

        private bool _disposed;

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