using Sevkiyat.Takip.Core.Entities;

namespace Sevkiyat.Takip.Domain.Entities;

public class Ilce : BaseEntity<int>
{
    public string Name { get; set; } = null!;
    public int SehirId { get; set; }
    public virtual Sehir Sehir { get; set; } = null!;
    public virtual ICollection<Ilan> AlinacakIlans { get; set; }
    public virtual ICollection<Ilan> TeslimEdilecekIlans { get; set; }
    public Ilce()
    {
        AlinacakIlans = new List<Ilan>();
        TeslimEdilecekIlans = new List<Ilan>();
    }
    public Ilce(string name, int sehirId, Sehir sehir,ICollection<Ilan> alinacakIlans,
        ICollection<Ilan> teslimEdilecekIlans)
    {
        Name = name;
        SehirId = sehirId;
        Sehir = sehir;
        AlinacakIlans = alinacakIlans;
        TeslimEdilecekIlans = teslimEdilecekIlans;
    }
}
