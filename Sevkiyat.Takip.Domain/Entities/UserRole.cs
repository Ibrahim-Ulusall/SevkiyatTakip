using Sevkiyat.Takip.Core.Entities;
using Sevkiyat.Takip.Domain.Entities.MuhasebeEntities;

namespace Sevkiyat.Takip.Domain.Entities;
public class UserRole : BaseEntity<int>
{
    public Guid UserId { get; set; }
    public int RoleId { get; set; }
    public Role Role { get; set; } = null!;
    public User User { get; set; } = null!;
}
