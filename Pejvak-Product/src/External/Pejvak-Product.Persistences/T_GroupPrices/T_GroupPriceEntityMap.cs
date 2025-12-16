using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pejvak_Product.Domain.GroupPrices;

namespace Pejvak_Product.Persistences.T_GroupPrices
{
    public class T_GroupPriceEntityMap : IEntityTypeConfiguration<T_GroupPrice>
    {
        public void Configure(EntityTypeBuilder<T_GroupPrice> builder)
        {
            builder.ToTable("T_GroupPrice");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired();

            builder.Property(x => x.PropertyId)
                .IsRequired(false);

            builder.Property(x => x.Price)
                .IsRequired(false);

            builder.Property(x => x.CoefficientPriceClient)
                .IsRequired(false);

            builder.Property(x => x.ProductGroupId)
                .IsRequired(false);

            builder.Property(x => x.PixName)
                .HasColumnType("nvarchar(max)")
                .IsRequired(false);

            builder.Property(x => x.Description)
                .HasColumnType("nvarchar(max)")
                .IsRequired(false);

            builder.Property(x => x.IsDeleted)
                .IsRequired();

            builder.Property(x => x.IsActive)
                .IsRequired();

            builder.Property(x => x.CompatibilityTypeServserAndClientLookupId)
                .IsRequired();

            builder.Property(x => x.VideoName)
                .HasMaxLength(500)
                .IsRequired(false);

            builder.Property(x => x.ThumbNames)
                .HasColumnType("nvarchar(max)")
                .IsRequired(false);

            builder.Property(x => x.FeaturesDescription)
                .HasColumnType("nvarchar(max)")
                .IsRequired(false);

            builder.Property(x => x.UsageDescription)
                .HasColumnType("nvarchar(max)")
                .IsRequired(false);

            builder.Property(x => x.DescriptionSummery)
                .HasMaxLength(200)
                .IsRequired(false);
        }
    }
}
