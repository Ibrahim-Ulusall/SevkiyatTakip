using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sevkiyat.Takip.Domain.Entities;

namespace Sevkiyat.Takip.Persistance.EntityConfigurations;

public class FirmaYetkiliTypeCofiguration : IEntityTypeConfiguration<FirmaYetkili>
{
    public void Configure(EntityTypeBuilder<FirmaYetkili> entity)
    {
        entity.HasKey(e => e.Id).HasName("firma_yetkililer_pkey");

        entity.ToTable("firma_yetkililer", "isletmeler");

        entity.HasIndex(e => e.FirmaId, "IX_firma_yetkililer_firma_id");

        entity.HasIndex(e => e.UserId, "IX_firma_yetkililer_user_id");

        entity.Property(e => e.CreatedDate).HasColumnName("created_date");
        entity.Property(e => e.DeletedDate).HasColumnName("deleted_date");
        entity.Property(e => e.FirmaId).HasColumnName("firma_id");
        entity.Property(e => e.UpdatedDate).HasColumnName("updated_date");
        entity.Property(e => e.UserId).HasColumnName("user_id");

        entity.HasOne(d => d.Firma).WithMany(p => p.FirmaYetkililers)
            .HasForeignKey(d => d.FirmaId)
            .HasConstraintName("firma_firma_yetkili_fk");

        entity.HasOne(d => d.User).WithMany(p => p.FirmaYetkililers)
            .HasForeignKey(d => d.UserId)
            .HasConstraintName("user_firma_yetkili_fk");

        entity.HasQueryFilter(i => !i.DeletedDate.HasValue);
    }
}
