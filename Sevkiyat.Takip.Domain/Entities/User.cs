using Microsoft.AspNetCore.Identity;

namespace Sevkiyat.Takip.Domain.Entities;

public class User : IdentityUser<Guid>
{
    public string Firstname { get; set; } = null!;
    public string Lastname { get; set; } = null!;
    public bool IsActive { get; set; }
    public DateTime CreatedDate { get; set; }

    public User() : base()
    {
        CreatedDate = DateTime.Now;
        this.TwoFactorEnabled = false;
    }
}
