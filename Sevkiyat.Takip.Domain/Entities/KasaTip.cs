using Sevkiyat.Takip.Core.Entities;

namespace Sevkiyat.Takip.Domain.Entities;

public class KasaTip : BaseEntity<int>
{
    public string Name { get; set; } = null!;
    public virtual ICollection<Ilan> Ilans { get; set; }
    public KasaTip()
    {
        Ilans = new List<Ilan>();
    }
    public KasaTip(string name,ICollection<Ilan> ilans)
    {
        Name = name;
        Ilans = ilans;
    }
}
