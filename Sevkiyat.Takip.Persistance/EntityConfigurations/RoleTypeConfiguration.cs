using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sevkiyat.Takip.Domain.Entities.MuhasebeEntities;


namespace Sevkiyat.Takip.Persistance.EntityConfigurations;

public class RoleTypeConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("roles", "accounts");
        builder.HasKey(x => x.Id).HasName("roles_pkey");
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.Name).HasColumnName("name").IsRequired();
        builder.Property(x => x.CreatedDate).HasColumnName("created_date");
        builder.Property(x => x.DeletedDate).HasColumnName("deleted_date");
        builder.Property(x => x.UpdatedDate).HasColumnName("updated_date");

        builder.HasQueryFilter(x => !x.DeletedDate.HasValue);
    }
}
