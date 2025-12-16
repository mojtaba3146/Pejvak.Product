using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pejvak_Product.Domain.T_Products;

namespace Pejvak_Product.Persistences.T_Products
{
    public class T_ProductEntityMap : IEntityTypeConfiguration<T_Product>
    {
        public void Configure(EntityTypeBuilder<T_Product> builder)
        {
            builder.ToTable("T_Product");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired();

            builder.Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.ExclusiveCode)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.ProductType)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.AssociateId)
                .IsRequired();

            builder.Property(x => x.ProductGroupId)
                .IsRequired();

            builder.Property(x => x.IsActive)
                .IsRequired();

            builder.Property(x => x.IsDeleted)
                .IsRequired();

            builder.Property(x => x.Price)
                .IsRequired();

            builder.Property(x => x.IsCenter)
                .IsRequired();

            builder.Property(x => x.Prefix)
                .HasMaxLength(500)
                .IsRequired(false);

            builder.Property(x => x.ClientDiscountPercantage)
                .IsRequired();

            builder.Property(x => x.ProductClassId)
                .IsRequired(false);

            builder.Property(x => x.ProductTypeId)
                .IsRequired()
                .HasDefaultValue(1);

            builder.Property(x => x.Pic1)
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(x => x.Pic2)
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(x => x.Pic3)
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(x => x.ExclusiveSetting)
                .HasColumnType("nvarchar(max)")
                .IsRequired(false);

            builder.Property(x => x.ActivationPrice)
                .IsRequired(false);

            builder.Property(x => x.IsUpdateNecessery)
                .IsRequired(false);

            builder.Property(x => x.PicLogo)
                .HasColumnType("nvarchar(max)")
                .IsRequired(false);

            builder.Property(x => x.ProductDescriptionLink)
                .HasMaxLength(1000)
                .IsRequired(false);

            builder.Property(x => x.ProductLink)
                .HasMaxLength(500)
                .IsRequired(false);

            builder.Property(x => x.Description)
                .HasMaxLength(2500)
                .IsRequired(false);
        }
    }
}
