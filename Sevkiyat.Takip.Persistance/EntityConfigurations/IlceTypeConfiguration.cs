using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sevkiyat.Takip.Domain.Entities;

namespace Sevkiyat.Takip.Persistance.EntityConfigurations;

public class IlceTypeConfiguration : IEntityTypeConfiguration<Ilce>
{
    public void Configure(EntityTypeBuilder<Ilce> entity)
    {
        entity.HasKey(e => e.Id).HasName("ilceler_pkey");

        entity.ToTable("ilceler", "bolgeler");

        entity.HasIndex(e => e.SehirId, "IX_ilceler_sehir_id");

        entity.Property(e => e.Id).HasColumnName("id");
        entity.Property(e => e.CreatedDate).HasColumnName("created_date");
        entity.Property(e => e.DeletedDate).HasColumnName("deleted_date");
        entity.Property(e => e.Name)
            .HasMaxLength(50)
            .HasColumnName("name");
        entity.Property(e => e.SehirId).HasColumnName("sehir_id");
        entity.Property(e => e.UpdatedDate).HasColumnName("updated_date");

        entity.HasOne(d => d.Sehir).WithMany(p => p.Ilcelers)
            .HasForeignKey(d => d.SehirId)
            .HasConstraintName("sehir_ilce_fk");

        entity.HasQueryFilter(i => !i.DeletedDate.HasValue);
    }
}
