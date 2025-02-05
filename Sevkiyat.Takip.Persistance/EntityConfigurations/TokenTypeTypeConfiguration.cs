using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sevkiyat.Takip.Domain.Entities.MuhasebeEntities;


namespace Sevkiyat.Takip.Persistance.EntityConfigurations;

public class TokenTypeTypeConfiguration : IEntityTypeConfiguration<TokenType>
{
    public void Configure(EntityTypeBuilder<TokenType> builder)
    {
        builder.ToTable("token_types", "accounts");
        builder.HasKey(i => i.Id).HasName("token_types_pkey");

        builder.Property(i => i.Id).HasColumnName("id").IsRequired();
        builder.Property(i => i.Name).HasColumnName("adi").IsRequired();
        builder.Property(i => i.CreatedDate).HasColumnName("created_date").IsRequired();
        builder.Property(i => i.UpdatedDate).HasColumnName("updated_date");
        builder.Property(i => i.DeletedDate).HasColumnName("deleted_date");

        builder.HasQueryFilter(i => !i.DeletedDate.HasValue);

    }
}
