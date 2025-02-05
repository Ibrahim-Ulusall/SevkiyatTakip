using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sevkiyat.Takip.Domain.Entities;

namespace Sevkiyat.Takip.Persistance.EntityConfigurations;

public class UserRoleTypeConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.ToTable("user_roles", "accounts");
        builder.HasKey(x => x.Id).HasName("user_roles_pkey");
        builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
        builder.Property(x => x.UserId).HasColumnName("user_id").IsRequired();
        builder.Property(x => x.RoleId).HasColumnName("role_id").IsRequired();
        builder.Property(x => x.CreatedDate).HasColumnName("created_date").IsRequired();
        builder.Property(x => x.DeletedDate).HasColumnName("deleted_date");
        builder.Property(x => x.UpdatedDate).HasColumnName("updated_date");

        builder.HasOne(x => x.User).WithMany(x => x.UserRoles).HasForeignKey(x => x.UserId).HasConstraintName("user_roles_user_id_fkey");
        builder.HasOne(x => x.Role).WithMany(x => x.UserRoles).HasForeignKey(x => x.RoleId).HasConstraintName("user_roles_role_id_fkey");
        builder.HasQueryFilter(x => !x.DeletedDate.HasValue);
    }
}