using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sevkiyat.Takip.Domain.Entities;

namespace Sevkiyat.Takip.Persistance.EntityConfigurations;

public class UserOperationClaimTypeConfiguration : IEntityTypeConfiguration<UserOperationClaim>
{
    public void Configure(EntityTypeBuilder<UserOperationClaim> builder)
    {
        builder.ToTable("user_operation_claims", "accounts");
        builder.HasKey(uo => uo.Id);
        builder.Property(uo => uo.UserId).HasColumnName("user_id").IsRequired();
        builder.Property(uo => uo.OperationClaimId).HasColumnName("operation_claim_id").IsRequired();
        builder.Property(u => u.CreatedDate).HasColumnName("created_date").IsRequired();
        builder.Property(u => u.DeletedDate).HasColumnName("deleted_date");
        builder.Property(u => u.UpdatedDate).HasColumnName("updated_date");
        builder.HasOne(uo => uo.User).WithMany(uo => uo.UserOperationClaims);
        builder.HasOne(uo => uo.OperationClaim).WithMany(uo => uo.UserOperationClaims);
        builder.HasQueryFilter(uo => !uo.DeletedDate.HasValue);
    }
}
