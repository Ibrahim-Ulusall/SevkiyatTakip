using Sevkiyat.Takip.Core.Entities;

namespace Sevkiyat.Takip.Domain.Entities;

public class Ilce : BaseEntity<int>
{
    public string Name { get; set; } = null!;
    public int SehirId { get; set; }
    public virtual Sehir Sehir { get; set; } = null!;
    public Ilce()
    {

    }
    public Ilce(string name, int sehirId, Sehir sehir)
    {
        Name = name;
        SehirId = sehirId;
        Sehir = sehir;
    }
}
