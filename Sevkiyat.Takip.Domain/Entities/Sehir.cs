using Sevkiyat.Takip.Core.Entities;

namespace Sevkiyat.Takip.Domain.Entities;

public class Sehir : BaseEntity<int>
{
    public string Name { get; set; } = null!;
    public int UlkeId { get; set; }
    public virtual Ulke Ulke { get; set; } = null!;
    public virtual ICollection<Ilce> Ilces { get; set; }
    public virtual ICollection<Ilan> AlinacakIlans { get; set; }
    public virtual ICollection<Ilan> TeslimEdilecekIlans { get; set; }
    public Sehir()
    {
        Ilces = new List<Ilce>();
        AlinacakIlans = new List<Ilan>();
        TeslimEdilecekIlans = new List<Ilan>();
    }

    public Sehir(string name, int ulkeId, Ulke ulke,
        ICollection<Ilce> ilces, ICollection<Ilan> alinacakIlans, ICollection<Ilan> teslimEdilecekIlan)
    {
        Name = name;
        UlkeId = ulkeId;
        Ulke = ulke;
        Ilces = ilces;
        AlinacakIlans = alinacakIlans;
        TeslimEdilecekIlans = teslimEdilecekIlan;
    }
}
