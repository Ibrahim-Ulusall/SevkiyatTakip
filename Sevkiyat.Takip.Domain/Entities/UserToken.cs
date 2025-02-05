using Sevkiyat.Takip.Core.Entities;
using Sevkiyat.Takip.Domain.Entities.MuhasebeEntities;

namespace Sevkiyat.Takip.Domain.Entities;

public class UserToken : BaseEntity<int>
{
    public Guid UserId { get; set; }
    public int TokenTypeId { get; set; }
    public string Token { get; set; } = null!;
    public virtual User User { get; set; } = null!;
    public virtual TokenType TokenType { get; set; } = null!;
}