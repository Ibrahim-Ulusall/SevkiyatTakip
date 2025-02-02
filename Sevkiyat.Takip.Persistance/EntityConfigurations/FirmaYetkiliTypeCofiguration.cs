using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sevkiyat.Takip.Domain.Entities;

namespace Sevkiyat.Takip.Persistance.EntityConfigurations;

public class FirmaYetkiliTypeCofiguration : IEntityTypeConfiguration<FirmaYetkili>
{
    public void Configure(EntityTypeBuilder<FirmaYetkili> builder)
    {
        builder.ToTable("firma_yetkililer", "isletmeler");

        builder.HasKey(i => i.Id).HasName("firma_yetkililer_pkey");

        builder.Property(i => i.UserId).HasColumnName("user_id").IsRequired();
        builder.Property(i => i.FirmaId).HasColumnName("firma_id").IsRequired();
        builder.Property(i => i.CreatedDate).HasColumnName("created_date").IsRequired();
        builder.Property(i => i.DeletedDate).HasColumnName("deleted_date");
        builder.Property(i => i.UpdatedDate).HasColumnName("updated_date");

        builder.HasOne(i => i.Firma).WithMany(i => i.FirmaYetkilis)
            .HasForeignKey(i => i.FirmaId).HasConstraintName("firma_firma_yetkili_fk")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(i => i.User).WithMany(i => i.FirmaYetkilis)
            .HasForeignKey(i => i.UserId).HasConstraintName("user_firma_yetkili_fk")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasQueryFilter(i => !i.DeletedDate.HasValue);
    }
}
