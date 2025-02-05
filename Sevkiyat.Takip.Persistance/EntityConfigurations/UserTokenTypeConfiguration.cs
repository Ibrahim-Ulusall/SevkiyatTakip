using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sevkiyat.Takip.Domain.Entities;

namespace Sevkiyat.Takip.Persistance.EntityConfigurations;

public class UserTokenTypeConfiguration : IEntityTypeConfiguration<UserToken>
{
    public void Configure(EntityTypeBuilder<UserToken> builder)
    {
        builder.ToTable("user_tokens", "accounts");
        builder.HasKey(i => i.Id).HasName("user_tokens_pkey");

        builder.Property(i => i.Id).HasColumnName("id").IsRequired();
        builder.Property(i => i.UserId).HasColumnName("user_id").IsRequired();
        builder.Property(i => i.TokenTypeId).HasColumnName("token_type_id").IsRequired();
        builder.Property(i => i.Token).HasColumnName("token").IsRequired();
        builder.Property(i => i.CreatedDate).HasColumnName("created_date").IsRequired();
        builder.Property(i => i.UpdatedDate).HasColumnName("updated_date");
        builder.Property(i => i.DeletedDate).HasColumnName("deleted_date");

        builder.HasOne(i => i.User).WithMany(i => i.UserTokens)
            .HasForeignKey(i => i.UserId)
            .HasConstraintName("user_tokens_user_id_fkey");

        builder.HasOne(i => i.TokenType).WithMany(i => i.UserTokens)
            .HasForeignKey(i => i.TokenTypeId)
            .HasConstraintName("user_tokens_token_type_id_fkey");

        builder.HasQueryFilter(i => !i.DeletedDate.HasValue);

    }
}
