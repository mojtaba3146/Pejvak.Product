using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pejvak_Product.Persistences.T_ProductInstanceProperties
{
    public class ProductInstancePropertyEntityMap : 
        IEntityTypeConfiguration<Domain.ProductInstanceProperties.T_ProductInstanceProperties>
    {
        public void Configure(EntityTypeBuilder<Domain.ProductInstanceProperties.T_ProductInstanceProperties> builder)
        {
            builder.ToTable("T_ProductInstanceProperties");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired();

            builder.Property(x => x.ProductId)
                .IsRequired(false);

            builder.Property(x => x.Version)
                .HasMaxLength(50)
                .IsRequired(false);

            builder.Property(x => x.Properties)
                .HasMaxLength(500)
                .IsRequired(false);

            builder.Property(x => x.FatherId)
                .IsRequired(false);

            builder.Property(x => x.IsActive)
                .IsRequired(false);

            builder.Property(x => x.IsDeleted)
                .IsRequired(false);
        }
    }
}
