using Sevkiyat.Takip.Core.Entities;

namespace Sevkiyat.Takip.Domain.Entities;

public class Ulke : BaseEntity<int>
{
    public string Name { get; set; } = null!;
    public virtual ICollection<Sehir> Sehirs { get; set; }
    public virtual ICollection<Ilan> AlinacakIlans { get; set; }
    public virtual ICollection<Ilan> TeslimEdilecekIlans { get; set; }

    public Ulke()
    {
        Sehirs = new HashSet<Sehir>();
        AlinacakIlans = new HashSet<Ilan>();
        TeslimEdilecekIlans = new HashSet<Ilan>();
    }
    public Ulke(string name) : this()
    {
        Name = name;
    }

    public Ulke(string name, ICollection<Sehir> sehirs,ICollection<Ilan> alinacakIlans,
        ICollection<Ilan> teslimEdilecekIlans)
    {
        Name = name;
        Sehirs = sehirs;
        AlinacakIlans = alinacakIlans;
        TeslimEdilecekIlans = teslimEdilecekIlans;
    }
}
