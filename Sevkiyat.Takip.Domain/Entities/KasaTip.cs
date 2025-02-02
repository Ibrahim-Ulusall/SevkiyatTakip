using Sevkiyat.Takip.Core.Entities;

namespace Sevkiyat.Takip.Domain.Entities;

public class KasaTip : BaseEntity<int>
{
    public string Name { get; set; } = null!;
    public KasaTip(string name) => Name = name;
}
