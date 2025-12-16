using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pejvak_Product.Domain.T_ProductInstances;

namespace Pejvak_Product.Persistences.T_ProductInstances
{
    public class T_ProductInstanceEntityMap : IEntityTypeConfiguration<T_ProductInstance>
    {
        public void Configure(EntityTypeBuilder<T_ProductInstance> builder)
        {
            builder.ToTable("T_ProductInstance");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired();

            builder.Property(x => x.ProductId)
                .IsRequired(false);

            builder.Property(x => x.AgentId)
                .IsRequired(false);

            builder.Property(x => x.LockSerial)
                .HasMaxLength(256)
                .IsRequired(false);

            builder.Property(x => x.ProductDate)
                .IsRequired(false);

            builder.Property(x => x.IsDeleted)
                .IsRequired(false);

            builder.Property(x => x.IsActive)
                .IsRequired(false);

            builder.Property(x => x.GoogleRegistrationCode)
                .HasColumnType("nvarchar(max)")
                .IsRequired(false);

            builder.Property(x => x.IsClient)
                .IsRequired(false);

            builder.Property(x => x.Vip)
                .HasMaxLength(10)
                .IsRequired(false)
                .HasDefaultValue(0);

            builder.Property(x => x.NextProductId)
                .IsRequired(false);

            builder.Property(x => x.IsPayed)
                .IsRequired(false);

            builder.Property(x => x.SellerId)
                .IsRequired(false)
                .HasDefaultValue(0);

            builder.Property(x => x.IsUpdateNecessary)
                .IsRequired(false);

            builder.Property(x => x.PriviousLockData)
                .HasColumnType("nvarchar(max)")
                .IsRequired(false);

            builder.Property(x => x.OldLockData)
                .HasColumnType("nvarchar(max)")
                .IsRequired(false);

            builder.Property(x => x.AmaniUserId)
                .IsRequired(false);

            builder.Property(x => x.UseExpiredSoftware)
                .IsRequired(false);

            builder.Property(x => x.CurrentVersion)
                .HasMaxLength(50)
                .IsRequired(false);

            builder.Property(x => x.IsItPrince)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(x => x.StatusLock)
                .IsRequired()
                .HasDefaultValue((byte)0);

            builder.Property(x => x.ActivationStatus)
                .IsRequired()
                .HasDefaultValue((byte)0);

            builder.Property(x => x.LastUpdateAt)
                .IsRequired(false);

            builder.Property(x => x.NickName)
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(x => x.JobId)
                .IsRequired(false);

            builder.Property(x => x.JobCategoryId)
                .IsRequired(false);
        }
    }
}
