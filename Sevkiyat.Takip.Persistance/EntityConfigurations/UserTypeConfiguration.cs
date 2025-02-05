using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Sevkiyat.Takip.Domain.Entities;

namespace Sevkiyat.Takip.Persistance.EntityConfigurations;

public class UserTypeConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users", "accounts");
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnName("id");
        builder.Property(u => u.FirstName).HasColumnName("firstname").IsRequired();
        builder.Property(u => u.LastName).HasColumnName("lastname");
        builder.Property(u => u.PasswordHash).HasColumnName("password_hash").IsRequired();
        builder.Property(u => u.PasswordSalt).HasColumnName("password_salt").IsRequired();
        builder.Property(u => u.Status).HasColumnName("status").IsRequired().HasDefaultValue(true);
        builder.Property(u => u.CreatedDate).HasColumnName("created_date").IsRequired();
        builder.Property(u => u.DeletedDate).HasColumnName("deleted_date");
        builder.Property(u => u.UpdatedDate).HasColumnName("updated_date");
        builder.Property(u => u.TokenExpiration).HasColumnName("token_expiration");
        builder.Property(u => u.Token).HasColumnName("token");
        builder.Property(u => u.LastPage).HasColumnName("last_page");
        builder.Property(u => u.Email).HasColumnName("email");
        builder.Property(u => u.TwoFactorEnabled).HasColumnName("two_factor_enabled");
        builder.Property(u => u.IgnoreTwoFactor).HasColumnName("ignore_two_factor");
        builder.Property(u => u.ForgotPasswordToken).HasColumnName("forgot_password_token");
        builder.Property(u => u.ForgotPasswordTokenExpiration).HasColumnName("forgot_password_token_expiration");
        builder.Property(u => u.Photo).HasColumnName("photo");

        builder.HasMany(u => u.UserOperationClaims).WithOne(u => u.User);
        
        builder.HasQueryFilter(u => !u.DeletedDate.HasValue);
    }
}
