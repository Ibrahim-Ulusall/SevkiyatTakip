using Sevkiyat.Takip.Core.Entities;

namespace Sevkiyat.Takip.Domain.Entities;

public class YukTip : BaseEntity<int>
{
    public string Name { get; set; } = null!;
    public ICollection<Ilan> Ilans { get; set; }
    public YukTip()
    {
        Ilans = new List<Ilan>();
    }
    public YukTip(string name, ICollection<Ilan> ilans)
    {
        Name = name;
        Ilans = ilans;
    }
}
