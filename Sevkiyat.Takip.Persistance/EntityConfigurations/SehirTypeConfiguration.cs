using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sevkiyat.Takip.Domain.Entities;

namespace Sevkiyat.Takip.Persistance.EntityConfigurations;

public class SehirTypeConfiguration : IEntityTypeConfiguration<Sehir>
{
    public void Configure(EntityTypeBuilder<Sehir> entity)
    {
        entity.HasKey(e => e.Id).HasName("sehirler_pkey");

        entity.ToTable("sehirler", "bolgeler");

        entity.HasIndex(e => e.UlkeId, "IX_sehirler_ulke_id");

        entity.Property(e => e.Id).HasColumnName("id");
        entity.Property(e => e.CreatedDate).HasColumnName("created_date");
        entity.Property(e => e.DeletedDate).HasColumnName("deleted_date");
        entity.Property(e => e.Name)
            .HasMaxLength(50)
            .HasColumnName("name");
        entity.Property(e => e.UlkeId).HasColumnName("ulke_id");
        entity.Property(e => e.UpdatedDate).HasColumnName("updated_date");

        entity.HasOne(d => d.Ulke).WithMany(p => p.Sehirlers)
            .HasForeignKey(d => d.UlkeId)
            .HasConstraintName("ulke_sehir_fk");

        entity.HasQueryFilter(i => !i.DeletedDate.HasValue);
    }
}

