using Sevkiyat.Takip.Core.Entities;

namespace Sevkiyat.Takip.Domain.Entities;

public class KasaTip : BaseEntity<int>
{
    public string Name { get; set; } = null!;
    public virtual ICollection<Ilan> Ilanlars { get; set; } = new List<Ilan>();
    public KasaTip()
    {
        Ilanlars = new List<Ilan>();
    }
    public KasaTip(string name,ICollection<Ilan> ilans)
    {
        Name = name;
        Ilanlars = ilans;
    }
}
