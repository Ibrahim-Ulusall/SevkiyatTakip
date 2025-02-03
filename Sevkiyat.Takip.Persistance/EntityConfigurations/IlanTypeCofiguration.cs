using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sevkiyat.Takip.Domain.Entities;

namespace Sevkiyat.Takip.Persistance.EntityConfigurations;

public class IlanTypeCofiguration : IEntityTypeConfiguration<Ilan>
{
    public void Configure(EntityTypeBuilder<Ilan> builder)
    {
        builder.ToTable("ilanlar", "isletmeler");

        builder.HasKey(i => i.Id).HasName("ilanlar_pkey");

        builder.Property(i => i.Id).HasColumnName("id");
        builder.Property(i => i.AlinacakIlceId).HasColumnName("alinacak_ilce_id").IsRequired();

        builder.Property(i => i.TeslimEdilecekIlceId).HasColumnName("teslim_edilecek_ilce_id").IsRequired();

        builder.Property(i => i.FirmaId).HasColumnName("firma_id").IsRequired();
        builder.Property(i => i.YukTipiId).HasColumnName("yuk_tipi_id").IsRequired();
        builder.Property(i => i.TasitTipiId).HasColumnName("tasit_tipi_id").IsRequired();
        builder.Property(i => i.KasaTipiId).HasColumnName("kasa_tipi_id").IsRequired();
        builder.Property(i => i.Aciklama).HasColumnName("aciklama");
        builder.Property(i => i.YukAlimTarihi).HasColumnName("yuk_alim_tarihi");
        builder.Property(i => i.OnGorulenTeslimTarihi).HasColumnName("on_gorülen_teslim_tarihi");

        builder.Property(i => i.CreatedDate).HasColumnName("created_date").IsRequired();
        builder.Property(i => i.DeletedDate).HasColumnName("deleted_date");
        builder.Property(i => i.UpdatedDate).HasColumnName("updated_date");


        builder.HasOne(i => i.KasaTip).WithMany(i => i.Ilans)
            .HasForeignKey(i => i.KasaTipiId)
            .HasConstraintName("ilan_kasa_tip_fk")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(i => i.YukTip).WithMany(i => i.Ilans)
            .HasForeignKey(i => i.YukTipiId)
            .HasConstraintName("ilan_yuk_tip_fk")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(i => i.TasitTip).WithMany(i => i.Ilans)
            .HasForeignKey(i => i.TasitTipiId)
            .HasConstraintName("ilan_tasit_tip_fk")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(i => i.TeslimEdilecekIlce)
                .WithMany(i => i.TeslimEdilecekIlans)
                .HasForeignKey(i => i.TeslimEdilecekIlceId)
                .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(i => i.AlinacakIlce)
            .WithMany(ilce => ilce.AlinacakIlans)
            .HasForeignKey(i => i.AlinacakIlceId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasQueryFilter(i => !i.DeletedDate.HasValue);
    }
}
