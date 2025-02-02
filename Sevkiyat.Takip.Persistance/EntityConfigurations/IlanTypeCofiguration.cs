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

        builder.Property(i => i.AlinacakUlkeId).HasColumnName("alinacak_ulke_id").IsRequired();
        builder.Property(i => i.AlinacakSehirId).HasColumnName("alinacak_sehir_id").IsRequired();
        builder.Property(i => i.AlinacakIlceId).HasColumnName("alinacak_ilce_id").IsRequired();

        builder.Property(i => i.TeslimEdilecekUlkeId).HasColumnName("teslim_edilecek_ulke_id").IsRequired();
        builder.Property(i => i.TeslimEdilecekSehirId).HasColumnName("teslim_edilecek_sehir_id").IsRequired();
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


        builder.HasOne(i=> i.KasaTip).WithMany(i=> i.Ilans)
            .HasForeignKey(i=> i.KasaTipiId)
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
        
        builder.HasOne(i => i.AlinacakUlke).WithMany(i => i.AlinacakIlans)
            .HasForeignKey(i => i.AlinacakUlkeId)
            .HasConstraintName("ilan_alinacak_ulke_fk")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(i => i.TeslimEdilecekUlke).WithMany(i => i.TeslimEdilecekIlans)
            .HasForeignKey(i => i.TeslimEdilecekUlkeId)
            .HasConstraintName("ilan_teslim_edilecek_ulke_fk")
            .OnDelete(DeleteBehavior.Cascade);


        builder.HasOne(i => i.AlinacakSehir).WithMany(i => i.AlinacakIlans)
            .HasForeignKey(i => i.AlinacakSehirId)
            .HasConstraintName("ilan_alinacak_sehir_fk")
            .OnDelete(DeleteBehavior.Cascade);


        builder.HasOne(i => i.TeslimEdilecekSehir).WithMany(i => i.TeslimEdilecekIlans)
            .HasForeignKey(i => i.TeslimEdilecekSehirId)
            .HasConstraintName("ilan_teslim_edilecek_sehir_fk")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(i => i.AlinacakIlce).WithMany(i => i.AlinacakIlans)
           .HasForeignKey(i => i.AlinacakIlceId)
           .HasConstraintName("ilan_alinacak_ilce_fk")
           .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(i => i.TeslimEdilecekIlce).WithMany(i => i.TeslimEdilecekIlans)
           .HasForeignKey(i => i.TeslimEdilecekIlceId)
           .HasConstraintName("ilan_teslim_edilecek_ilce_fk")
           .OnDelete(DeleteBehavior.Cascade);

        builder.HasQueryFilter(i => !i.DeletedDate.HasValue);
    }
}
