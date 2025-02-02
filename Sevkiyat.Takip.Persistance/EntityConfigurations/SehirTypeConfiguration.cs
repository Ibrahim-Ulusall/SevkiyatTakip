using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sevkiyat.Takip.Domain.Entities;

namespace Sevkiyat.Takip.Persistance.EntityConfigurations;

public class SehirTypeConfiguration : IEntityTypeConfiguration<Sehir>
{
    public void Configure(EntityTypeBuilder<Sehir> builder)
    {
        builder.ToTable("sehirler", "bolgeler");

        builder.HasKey(x => x.Id).HasName("sehirler_pkey");

        builder.Property(i => i.Id).HasColumnName("id");
        builder.Property(i => i.Name).HasColumnName("name")
            .HasMaxLength(50).IsRequired();
        builder.Property(i => i.UlkeId).HasColumnName("ulke_id").IsRequired();
        builder.Property(i => i.CreatedDate).HasColumnName("created_date").IsRequired();
        builder.Property(i => i.DeletedDate).HasColumnName("deleted_date");
        builder.Property(i => i.UpdatedDate).HasColumnName("updated_date");

        builder.HasOne(i => i.Ulke).WithMany(i => i.Sehirs).HasForeignKey(i => i.UlkeId)
            .HasConstraintName("ulke_sehir_fk")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasQueryFilter(i => !i.DeletedDate.HasValue);
    }
}

