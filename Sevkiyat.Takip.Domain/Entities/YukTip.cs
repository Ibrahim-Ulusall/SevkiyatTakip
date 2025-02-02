using Sevkiyat.Takip.Core.Entities;

namespace Sevkiyat.Takip.Domain.Entities;

public class YukTip : BaseEntity<int>
{
    public string Name { get; set; } = null!;
    public YukTip(string name) => Name = name;
}
