using Microsoft.EntityFrameworkCore;
using Pejvak_Product.Domain.T_ProductHolders;
using Pejvak_Product.Domain.T_ProductInstances;

namespace Pejvak_Product.Persistences.Infrastructure
{
    public class EFDataContext : DbContext
    {
        public EFDataContext(DbContextOptions<EFDataContext> options) : base(options)
        {
        }

        public DbSet<T_ProductInstance> ProductInstances { get; set; }
        public DbSet<T_ProductHolder> ProductHolders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EFDataContext).Assembly);
        }
    }
}
