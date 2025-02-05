using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sevkiyat.Takip.Domain.Entities;

namespace Sevkiyat.Takip.Persistance.EntityConfigurations;

public class IlanTypeCofiguration : IEntityTypeConfiguration<Ilan>
{
    public void Configure(EntityTypeBuilder<Ilan> builder)
    {
        builder.HasKey(e => e.Id).HasName("ilanlar_pkey");

        builder.ToTable("ilanlar", "isletmeler");

        builder.HasIndex(e => e.AlinacakIlceId, "IX_ilanlar_alinacak_ilce_id");

        builder.HasIndex(e => e.FirmaId, "IX_ilanlar_firma_id");

        builder.HasIndex(e => e.KasaTipiId, "IX_ilanlar_kasa_tipi_id");

        builder.HasIndex(e => e.TasitTipiId, "IX_ilanlar_tasit_tipi_id");

        builder.HasIndex(e => e.TeslimIlceId, "IX_ilanlar_teslim_ilce_id");

        builder.HasIndex(e => e.YukTipiId, "IX_ilanlar_yuk_tipi_id");

        builder.Property(e => e.Id).HasColumnName("id");
        builder.Property(e => e.Aciklama).HasColumnName("aciklama");
        builder.Property(e => e.AlinacakIlceId).HasColumnName("alinacak_ilce_id");
        builder.Property(e => e.CreatedDate).HasColumnName("created_date");
        builder.Property(e => e.DeletedDate).HasColumnName("deleted_date");
        builder.Property(e => e.FirmaId).HasColumnName("firma_id");
        builder.Property(e => e.KasaTipiId).HasColumnName("kasa_tipi_id");
        builder.Property(e => e.OnGorülenTeslimTarihi).HasColumnName("on_gorülen_teslim_tarihi");
        builder.Property(e => e.TasitTipiId).HasColumnName("tasit_tipi_id");
        builder.Property(e => e.TeslimIlceId)
            .HasColumnName("teslim_ilce_id");
        builder.Property(e => e.UpdatedDate).HasColumnName("updated_date");
        builder.Property(e => e.YukAlimTarihi).HasColumnName("yuk_alim_tarihi");
        builder.Property(e => e.YukTipiId).HasColumnName("yuk_tipi_id");

        builder.HasOne(d => d.AlinacakIlce).WithMany(p => p.IlanlarAlinacakIlces).HasForeignKey(d => d.AlinacakIlceId);

        builder.HasOne(d => d.Firma).WithMany(p => p.Ilanlars).HasForeignKey(d => d.FirmaId);

        builder.HasOne(d => d.KasaTipi).WithMany(p => p.Ilanlars)
            .HasForeignKey(d => d.KasaTipiId)
            .HasConstraintName("ilan_kasa_tip_fk");

        builder.HasOne(d => d.TasitTipi).WithMany(p => p.Ilanlars)
            .HasForeignKey(d => d.TasitTipiId)
            .HasConstraintName("ilan_tasit_tip_fk");

        builder.HasOne(d => d.TeslimIlce).WithMany(p => p.IlanlarTeslimIlces).HasForeignKey(d => d.TeslimIlceId);

        builder.HasOne(d => d.YukTipi).WithMany(p => p.Ilanlars)
            .HasForeignKey(d => d.YukTipiId)
            .HasConstraintName("ilan_yuk_tip_fk");

        builder.HasQueryFilter(i => !i.DeletedDate.HasValue);
    }
}
