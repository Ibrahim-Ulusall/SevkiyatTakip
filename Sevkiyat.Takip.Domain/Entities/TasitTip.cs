using Sevkiyat.Takip.Core.Entities;

namespace Sevkiyat.Takip.Domain.Entities;
public class TasitTip : BaseEntity<int>
{
    public string Name { get; set; } = null!;
    public TasitTip(string name) => Name = name;
}
