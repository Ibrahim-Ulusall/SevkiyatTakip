using Sevkiyat.Takip.Core.Entities;

namespace Sevkiyat.Takip.Domain.Entities;

public class Sehir : BaseEntity<int>
{
    public string Name { get; set; } = null!;
    public int UlkeId { get; set; }
    public virtual Ulke Ulke { get; set; } = null!;
    public virtual ICollection<Ilce> Ilcelers { get; set; } = new List<Ilce>();
}
