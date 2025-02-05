using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sevkiyat.Takip.Domain.Entities;

namespace Sevkiyat.Takip.Persistance.EntityConfigurations;

public class OperationClaimTypeConfiguration : IEntityTypeConfiguration<OperationClaim>
{
    public void Configure(EntityTypeBuilder<OperationClaim> builder)
    {
        builder.ToTable("operation_claims", "accounts");
        builder.HasKey(op => op.Id);
        builder.Property(op => op.Id).HasColumnName("id").IsRequired();
        builder.Property(op => op.Name).HasColumnName("name").IsRequired();
        builder.Property(op => op.RoleId).HasColumnName("role_id");
        builder.Property(op => op.CreatedDate).HasColumnName("created_date").IsRequired();
        builder.Property(op => op.DeletedDate).HasColumnName("deleted_date");
        builder.Property(op => op.UpdatedDate).HasColumnName("updated_date");

        builder.HasOne(op => op.Role).WithMany(op => op.Claims).HasForeignKey(op => op.RoleId)
            .HasConstraintName("operation_claims_role_id_fkey");
        builder.HasQueryFilter(op => !op.DeletedDate.HasValue);
    }
}
