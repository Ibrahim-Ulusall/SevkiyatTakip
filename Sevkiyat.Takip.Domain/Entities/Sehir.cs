using Sevkiyat.Takip.Core.Entities;

namespace Sevkiyat.Takip.Domain.Entities;

public class Sehir : BaseEntity<int>
{
    public string Name { get; set; } = null!;
    public int UlkeId { get; set; }
    public virtual Ulke Ulke { get; set; } = null!;
    public virtual ICollection<Ilce> Ilces { get; set; }
    public Sehir()
    {
        Ilces = new List<Ilce>();
    }

    public Sehir(string name, int ulkeId, Ulke ulke,
        ICollection<Ilce> ilces)
    {
        Name = name;
        UlkeId = ulkeId;
        Ulke = ulke;
        Ilces = ilces;
    }
}
