using Sevkiyat.Takip.Core.Entities;

namespace Sevkiyat.Takip.Domain.Entities;

public class YukTip : BaseEntity<int>
{
    public string Name { get; set; } = null!;
    public virtual ICollection<Ilan> Ilanlars { get; set; } = new List<Ilan>();
    public YukTip()
    {
        Ilanlars = new List<Ilan>();
    }
    public YukTip(string name, ICollection<Ilan> ilans)
    {
        Name = name;
        Ilanlars = ilans;
    }
}
