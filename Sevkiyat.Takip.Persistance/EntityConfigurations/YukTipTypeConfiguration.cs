using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sevkiyat.Takip.Domain.Entities;

namespace Sevkiyat.Takip.Persistance.EntityConfigurations;

public class YukTipTypeConfiguration : IEntityTypeConfiguration<YukTip>
{
    public void Configure(EntityTypeBuilder<YukTip> builder)
    {
        builder.ToTable("yuk_tipleri", "envanter");

        builder.HasKey(x => x.Id).HasName("yuk_tipleri_pkey");

        builder.Property(i => i.Id).HasColumnName("id");
        builder.Property(i => i.Name).HasColumnName("name")
            .HasMaxLength(50).IsRequired();
        builder.Property(i => i.CreatedDate).HasColumnName("created_date").IsRequired();
        builder.Property(i => i.DeletedDate).HasColumnName("deleted_date");
        builder.Property(i => i.UpdatedDate).HasColumnName("updated_date");

        builder.HasQueryFilter(i => !i.DeletedDate.HasValue);
    }
}

