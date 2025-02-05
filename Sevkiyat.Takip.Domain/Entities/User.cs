using Sevkiyat.Takip.Core.Entities;
using Sevkiyat.Takip.Core.Extensions;

namespace Sevkiyat.Takip.Domain.Entities;
public class User : BaseEntity<Guid>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string Email { get; set; } = null!;
    public byte[]? PasswordHash { get; set; }
    public byte[]? PasswordSalt { get; set; }
    public bool Status { get; set; }
    public string? LastPage { get; set; }
    public string? Token { get; set; }
    public DateTime? TokenExpiration { get; set; }
    public bool TwoFactorEnabled { get; set; }
    public bool IgnoreTwoFactor { get; set; }
    public string? Photo { get; set; }
    public string? ForgotPasswordToken { get; set; }
    public DateTime? ForgotPasswordTokenExpiration { get; set; }
    public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; } = new List<UserOperationClaim>();
    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    public virtual ICollection<UserToken> UserTokens { get; set; } = new List<UserToken>();
    public virtual ICollection<FirmaYetkili> FirmaYetkililers { get; set; } = new List<FirmaYetkili>();
    public string FullName
    {
        get
        {
            return $"{FirstName} {LastName}".ToCapitalize();
        }
    }
}