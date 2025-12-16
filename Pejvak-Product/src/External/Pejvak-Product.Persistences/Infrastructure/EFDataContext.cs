using Microsoft.EntityFrameworkCore;
using Pejvak_Product.Domain.GroupPrices;
using Pejvak_Product.Domain.ProductInstanceProperties;
using Pejvak_Product.Domain.ProductProductGroups;
using Pejvak_Product.Domain.T_ProductHolders;
using Pejvak_Product.Domain.T_ProductInstances;
using Pejvak_Product.Domain.T_Products;

namespace Pejvak_Product.Persistences.Infrastructure
{
    public class EFDataContext : DbContext
    {
        public EFDataContext(DbContextOptions<EFDataContext> options) : base(options)
        {
        }

        public DbSet<T_ProductInstance> ProductInstances { get; set; }
        public DbSet<T_ProductHolder> ProductHolders { get; set; }
        public DbSet<T_Product> Products { get; set; }
        public DbSet<Domain.ProductProperties.T_ProductProperties> ProductProperties { get; set; }
        public DbSet<T_GroupPrice> GroupPrices { get; set; }
        public DbSet<T_ProductProductGroup> ProductProductGroups { get; set; }
        public DbSet<Domain.ExtraFeatures.T_ExtraFeatures> ExtraFeatures { get; set; }
        public DbSet<Domain.ProductInstanceProperties.T_ProductInstanceProperties> ProductInstanceProperties { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EFDataContext).Assembly);
        }
    }
}
