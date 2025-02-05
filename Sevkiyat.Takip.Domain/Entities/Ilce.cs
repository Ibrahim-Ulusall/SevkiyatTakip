using Sevkiyat.Takip.Core.Entities;

namespace Sevkiyat.Takip.Domain.Entities;

public class Ilce : BaseEntity<int>
{
    public string Name { get; set; } = null!;

    public int SehirId { get; set; }

    public virtual ICollection<Ilan> IlanlarAlinacakIlces { get; set; } = new List<Ilan>();

    public virtual ICollection<Ilan> IlanlarTeslimIlces { get; set; } = new List<Ilan>();

    public virtual Sehir Sehir { get; set; } = null!;
}
