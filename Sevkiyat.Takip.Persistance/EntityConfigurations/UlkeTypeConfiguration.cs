using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sevkiyat.Takip.Domain.Entities;

namespace Sevkiyat.Takip.Persistance.EntityConfigurations;

public class UlkeTypeConfiguration : IEntityTypeConfiguration<Ulke>
{
    public void Configure(EntityTypeBuilder<Ulke> entity)
    {
        entity.HasKey(e => e.Id).HasName("ulkeler_pkey");

        entity.ToTable("ulkeler", "bolgeler");

        entity.Property(e => e.Id).HasColumnName("id");
        entity.Property(e => e.CreatedDate).HasColumnName("created_date");
        entity.Property(e => e.DeletedDate).HasColumnName("deleted_date");
        entity.Property(e => e.Kod)
            .HasDefaultValueSql("''::text")
            .HasColumnName("kod");
        entity.Property(e => e.Name)
            .HasMaxLength(50)
            .HasColumnName("name");
        entity.Property(e => e.TelefonKodu)
            .HasDefaultValueSql("''::text")
            .HasColumnName("telefon_kodu");
        entity.Property(e => e.UpdatedDate).HasColumnName("updated_date");

        entity.HasQueryFilter(i => !i.DeletedDate.HasValue);
    }
}

