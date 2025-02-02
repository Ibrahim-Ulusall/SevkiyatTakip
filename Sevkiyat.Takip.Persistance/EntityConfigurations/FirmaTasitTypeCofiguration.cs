using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sevkiyat.Takip.Domain.Entities;

namespace Sevkiyat.Takip.Persistance.EntityConfigurations;

public class FirmaTasitTypeCofiguration : IEntityTypeConfiguration<FirmaTasit>
{
    public void Configure(EntityTypeBuilder<FirmaTasit> builder)
    {
        builder.ToTable("firma_tasitlar", "isletmeler");

        builder.HasKey(i => i.Id).HasName("firma_tasitlar_pkey");

        builder.Property(i => i.TasitTipId).HasColumnName("tasit_tip_id")
            .IsRequired();

        builder.Property(i => i.FirmaId).HasColumnName("firma_id").IsRequired();
        builder.Property(i => i.CreatedDate).HasColumnName("created_date").IsRequired();
        builder.Property(i => i.DeletedDate).HasColumnName("deleted_date");
        builder.Property(i => i.UpdatedDate).HasColumnName("updated_date");

        builder.HasOne(i => i.Firma)
            .WithMany(i => i.FirmaTasits)
            .HasForeignKey(i => i.FirmaId)
            .HasConstraintName("firma_firma_tasitlar_fk")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(i => i.TasitTip)
            .WithMany(i => i.FirmaTasits)
            .HasForeignKey(i => i.TasitTipId)
            .HasConstraintName("tasit_tip_firma_tasitlar_fk")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasQueryFilter(i => !i.DeletedDate.HasValue);
    }
}
