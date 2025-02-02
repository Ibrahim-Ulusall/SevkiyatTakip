using Sevkiyat.Takip.Core.Entities;

namespace Sevkiyat.Takip.Domain.Entities;

public class Ulke : BaseEntity<int>
{
    public string Name { get; set; } = null!;
    public virtual ICollection<Sehir> Sehirs { get; set; }

    public Ulke()
    {
        Sehirs = new HashSet<Sehir>();
    }
    public Ulke(string name) : this()
    {
        Name = name;
    }

    public Ulke(string name, ICollection<Sehir> sehirs)
    {
        Name = name;
        Sehirs = sehirs;
    }
}
