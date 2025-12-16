using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pejvak_Product.Persistences.T_ExtraFeatures
{
    public class T_ExtraFeatureEntityMap : IEntityTypeConfiguration<Domain.ExtraFeatures.T_ExtraFeatures>
    {
        public void Configure(EntityTypeBuilder<Domain.ExtraFeatures.T_ExtraFeatures> builder)
        {
            builder.ToTable("T_ExtraFeatures");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired();

            builder.Property(x => x.ProductInstanceId)
                .IsRequired(false);

            builder.Property(x => x.ExtraFeatures)
                .HasMaxLength(500)
                .IsRequired(false);

            builder.Property(x => x.IsDeleted)
                .IsRequired(false);

            builder.Property(x => x.Confirmed)
                .IsRequired(false);

            builder.Property(x => x.Count)
                .IsRequired(false);
        }
    }
}
