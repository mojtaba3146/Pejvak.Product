using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Pejvak_Product.IntegrationTests.Infrastructure
{
    public class SqlDatabase<TDbContext> where TDbContext : DbContext, IDisposable
    {
        private TDbContext _dbContext = default!;
        public SqlDatabase()
        {
        }
        private ConstructorInfo? FindSuitableConstructor()
        {
            var flags = BindingFlags.Instance |
                        BindingFlags.Public |
                        BindingFlags.NonPublic |
                        BindingFlags.InvokeMethod;

            var constructor =
                typeof(TDbContext).GetConstructor(
                    flags,
                    binder: null,
                    [typeof(DbContextOptions<TDbContext>)],
                    modifiers: null);

            if (constructor == null)
            {
                constructor = typeof(TDbContext).GetConstructor(
                    flags,
                    binder: null,
                    [typeof(DbContextOptions)],
                    modifiers: null);
            }

            return constructor;
        }

        private Func<TDbContext> ResolveFactory()
        {
            var optionBuilder = new DbContextOptionsBuilder<TDbContext>();
            optionBuilder.EnableSensitiveDataLogging();
            var dbName = "server=.;database=pejvakproduct-test;Trusted_connection=true;TrustServerCertificate=True";
            var dbContextOptions = optionBuilder.UseSqlServer(dbName).Options;
            var constructor = FindSuitableConstructor();

            if (constructor == null)
            {
                throw new Exception($"no constructor found on '{typeof(TDbContext).Name}' " +
                                    "with one parameter of type " +
                                    $"DbContextOptions<{typeof(TDbContext).Name}>/DbContextOptions");
            }

            return () => (
            constructor.Invoke([dbContextOptions])
            as TDbContext)!;
        }

        public TDbContext CreateDataContext(params object[] entities)
        {
            _dbContext = ResolveFactory().Invoke();
            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();

            if (entities?.Length > 0)
            {
                _dbContext.AddRange(entities);
                _dbContext.SaveChanges();
            }

            return _dbContext;
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }
    }
}
