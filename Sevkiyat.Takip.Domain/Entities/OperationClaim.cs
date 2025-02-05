using Sevkiyat.Takip.Core.Entities;
using Sevkiyat.Takip.Domain.Entities.MuhasebeEntities;

namespace Sevkiyat.Takip.Domain.Entities;
public class OperationClaim : BaseEntity<Guid>
{
    public string? Name { get; set; }
    public int RoleId { get; set; }
    public Role Role { get; set; } = null!;
    public ICollection<UserOperationClaim>? UserOperationClaims { get; set; }
}
