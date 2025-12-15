using Microsoft.EntityFrameworkCore.Storage;
using Pejvak_Product.Services.Infrastructure;

namespace Pejvak_Product.Persistences.Infrastructure
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly EFDataContext _dataContext;
        private bool _isTransactionTriggerd;
        private IDbContextTransaction _contextTransaction;

        public UnitOfWork(EFDataContext dataContext)
        {
            _contextTransaction = default!;
            _dataContext = dataContext;
            _isTransactionTriggerd = false;
        }
        public async Task BeginTransaction()
        {
            _contextTransaction = await _dataContext.Database.BeginTransactionAsync();
            _isTransactionTriggerd = true;
        }

        public async Task CommitTransaction()
        {
            await _contextTransaction.CommitAsync();
        }

        public void Dispose()
        {
            _dataContext.Dispose();
        }

        public void DisposeTransaction()
        {
            _contextTransaction.Dispose();
        }

        public async Task RollbackTransaction()
        {
            await _contextTransaction.RollbackAsync();
        }

        public async Task SaveAsync()
        {
            await _dataContext.SaveChangesAsync();
        }
    }
}
