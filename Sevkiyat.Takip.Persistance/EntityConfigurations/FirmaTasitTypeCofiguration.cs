using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sevkiyat.Takip.Domain.Entities;

namespace Sevkiyat.Takip.Persistance.EntityConfigurations;

public class FirmaTasitTypeCofiguration : IEntityTypeConfiguration<FirmaTasit>
{
    public void Configure(EntityTypeBuilder<FirmaTasit> entity)
    {
        entity.HasKey(e => e.Id).HasName("firma_tasitlar_pkey");

        entity.ToTable("firma_tasitlar", "isletmeler");

        entity.HasIndex(e => e.FirmaId, "IX_firma_tasitlar_firma_id");

        entity.HasIndex(e => e.TasitTipId, "IX_firma_tasitlar_tasit_tip_id");

        entity.Property(e => e.CreatedDate).HasColumnName("created_date");
        entity.Property(e => e.DeletedDate).HasColumnName("deleted_date");
        entity.Property(e => e.FirmaId).HasColumnName("firma_id");
        entity.Property(e => e.TasitTipId).HasColumnName("tasit_tip_id");
        entity.Property(e => e.UpdatedDate).HasColumnName("updated_date");

        entity.HasOne(d => d.Firma).WithMany(p => p.FirmaTasitlars)
            .HasForeignKey(d => d.FirmaId)
            .HasConstraintName("firma_firma_tasitlar_fk");

        entity.HasOne(d => d.TasitTip).WithMany(p => p.FirmaTasitlars)
            .HasForeignKey(d => d.TasitTipId)
            .HasConstraintName("tasit_tip_firma_tasitlar_fk");

        entity.HasQueryFilter(i => !i.DeletedDate.HasValue);
    }
}
