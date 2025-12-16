using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pejvak_Product.Domain.T_ProductHolders;

namespace Pejvak_Product.Persistences.T_ProductHolders
{
    public class T_ProductHolderEntityMap : IEntityTypeConfiguration<T_ProductHolder>
    {
        public void Configure(EntityTypeBuilder<T_ProductHolder> builder)
        {
            builder.ToTable("T_ProductHolder");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired();

            builder.Property(x => x.UserId)
                .IsRequired(false);

            builder.Property(x => x.ProductInstanceId)
                .IsRequired(false);

            builder.Property(x => x.AssignmentType)
                .IsRequired(false);

            builder.Property(x => x.StartDate)
                .IsRequired(false);

            builder.Property(x => x.EndDate)
                .IsRequired(false);

            builder.Property(x => x.IsDeleted)
                .IsRequired(false);

            builder.Property(x => x.CustomerEdited)
                .IsRequired(false);
        }
    }
}
