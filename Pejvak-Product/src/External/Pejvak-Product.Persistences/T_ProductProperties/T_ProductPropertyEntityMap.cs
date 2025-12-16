using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pejvak_Product.Persistences.T_ProductProperties
{
    public class T_ProductPropertyEntityMap : IEntityTypeConfiguration<Domain.ProductProperties.T_ProductProperties>
    {
        public void Configure(EntityTypeBuilder<Domain.ProductProperties.T_ProductProperties> builder)
        {
            builder.ToTable("T_ProductProperties");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired();

            builder.Property(x => x.PropertyTitle)
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(x => x.UniqueCode)
                .HasMaxLength(50)
                .IsRequired(false);

            builder.Property(x => x.IsActive)
                .IsRequired(false);

            builder.Property(x => x.IsDeleted)
                .IsRequired(false);

            builder.Property(x => x.IsTimeSensitive)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(x => x.TimeSensitiveTitle)
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(x => x.DayCount)
                .IsRequired(false);

            builder.Property(x => x.SortKey)
                .HasMaxLength(50)
                .IsRequired(false);

            builder.Property(x => x.PropertyClassId)
                .IsRequired(false);
        }
    }
}
