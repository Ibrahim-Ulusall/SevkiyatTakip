using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sevkiyat.Takip.Domain.Entities;

namespace Sevkiyat.Takip.Persistance.EntityConfigurations;

public class IlceTypeConfiguration : IEntityTypeConfiguration<Ilce>
{
    public void Configure(EntityTypeBuilder<Ilce> builder)
    {
        builder.ToTable("ilceler", "bolgeler");

        builder.HasKey(x => x.Id).HasName("ilceler_pkey");

        builder.Property(i => i.Id).HasColumnName("id");
        builder.Property(i => i.Name).HasColumnName("name")
            .HasMaxLength(50).IsRequired();
        builder.Property(i => i.SehirId).HasColumnName("sehir_id").IsRequired();
        builder.Property(i => i.CreatedDate).HasColumnName("created_date").IsRequired();
        builder.Property(i => i.DeletedDate).HasColumnName("deleted_date");
        builder.Property(i => i.UpdatedDate).HasColumnName("updated_date");

        builder.HasOne(i => i.Sehir).WithMany(i => i.Ilces)
            .HasForeignKey(i => i.SehirId)
            .HasConstraintName("sehir_ilce_fk")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasQueryFilter(i => !i.DeletedDate.HasValue);
    }
}
