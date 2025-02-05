using Sevkiyat.Takip.Core.Entities;

namespace Sevkiyat.Takip.Domain.Entities;

public class Ulke : BaseEntity<int>
{
    public string Name { get; set; } = null!;
    public string Kod { get; set; } = null!;
    public string TelefonKodu { get; set; } = null!;
    public virtual ICollection<Sehir> Sehirlers { get; set; } = new List<Sehir>();

}
