using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pejvak_Product.Domain.ProductProductGroups;

namespace Pejvak_Product.Persistences.T_ProductProductGroups
{
    public class T_ProductProductGroupEntityMap : IEntityTypeConfiguration<T_ProductProductGroup>
    {
        public void Configure(EntityTypeBuilder<T_ProductProductGroup> builder)
        {
            builder.ToTable("T_ProductProductGroup");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired();

            builder.Property(x => x.ProductIds)
                .HasMaxLength(1000)
                .IsRequired();

            builder.Property(x => x.PropertyId)
                .IsRequired();

            builder.Property(x => x.IsDeleted)
                .IsRequired();

            builder.Property(x => x.IsActive)
                .IsRequired();
        }
    }
}
