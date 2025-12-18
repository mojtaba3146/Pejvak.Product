using Pejvak_Product.Persistences.Infrastructure;
using Pejvak_Product.Services.Infrastructure;

namespace Pejvak_Product.IntegrationTests.Infrastructure
{
    [Collection(nameof(IntegrationTestPersistence))]
    public class IntegrationTestPersistence
    {
        protected CancellationToken CancellationToken = default!;
        protected EFDataContext Context { get; }
        protected EFDataContext ReadContext { get; }

        public IntegrationTestPersistence()
        {
            var db = new SqlDatabase<EFDataContext>();
            Context = db.CreateDataContext();
            ReadContext = db.CreateDataContext();
        }

        protected void Save<T>(T entity)
        {
            GaurdIfEntityIsNull(entity);
            if (entity is IEntityTenant)
                SaveProperties(entity as IEntityTenant);
            Context.Add(entity!);
            Context.SaveChanges();
        }

        private static void GaurdIfEntityIsNull<T>(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
        }

        protected IUnitOfWork UnitOfWork { get { return new UnitOfWork(Context); } }

        private void SaveProperties(IEntityTenant? entityTenant)
        {
            entityTenant!.GetType().GetProperty("TenantId")?.SetValue(entityTenant, TenantUtilities.TenantId);
        }
    }

    [CollectionDefinition(nameof(IntegrationTestPersistence), DisableParallelization = false)]
    public class Option : ICollectionFixture<Option>
    {

    }
}
