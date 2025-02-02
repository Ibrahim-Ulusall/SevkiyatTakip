using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sevkiyat.Takip.Domain.Entities;

namespace Sevkiyat.Takip.Persistance.EntityConfigurations;

public class FirmaTypeCofiguration : IEntityTypeConfiguration<Firma>
{
    public void Configure(EntityTypeBuilder<Firma> builder)
    {
        builder.ToTable("firmalar", "isletmeler");

        builder.HasKey(i => i.Id).HasName("firmalar_pkey");

        builder.Property(i=> i.Adi).HasColumnName("adi").HasMaxLength(50).IsRequired();
        builder.Property(i => i.CreatedDate).HasColumnName("created_date").IsRequired();
        builder.Property(i => i.DeletedDate).HasColumnName("deleted_date");
        builder.Property(i => i.UpdatedDate).HasColumnName("updated_date");

        builder.HasQueryFilter(i => !i.DeletedDate.HasValue);
    }
}
