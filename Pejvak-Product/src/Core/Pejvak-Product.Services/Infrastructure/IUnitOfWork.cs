namespace Pejvak_Product.Services.Infrastructure
{
    public interface IUnitOfWork : IScope
    {
        Task BeginTransaction();
        Task CommitTransaction();
        Task RollbackTransaction();
        Task SaveAsync();
        void DisposeTransaction();
        void Dispose();
    }
}
