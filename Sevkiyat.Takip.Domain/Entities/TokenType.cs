using Sevkiyat.Takip.Core.Entities;

namespace Sevkiyat.Takip.Domain.Entities.MuhasebeEntities;

public class TokenType : BaseEntity<int>
{
    public string Name { get; set; } = null!;
    public virtual ICollection<UserToken> UserTokens { get; set; } = new List<UserToken>();
}
