using Sevkiyat.Takip.Core.Entities;
using Sevkiyat.Takip.Domain.Entities;

namespace Sevkiyat.Takip.Domain.Entities.MuhasebeEntities;
public class Role : BaseEntity<int>
{
    public string Name { get; set; } = null!;
    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    public ICollection<OperationClaim> Claims { get; set; } = new List<OperationClaim>();
}
