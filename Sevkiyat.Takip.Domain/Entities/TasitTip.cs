using Sevkiyat.Takip.Core.Entities;

namespace Sevkiyat.Takip.Domain.Entities;
public class TasitTip : BaseEntity<int>
{
    public string Name { get; set; } = null!;
    public virtual ICollection<FirmaTasit> FirmaTasits { get; set; }
    public virtual ICollection<Ilan> Ilans { get; set; }
    public TasitTip()
    {
        FirmaTasits = new List<FirmaTasit>();
        Ilans = new List<Ilan>();
    }
    public TasitTip(string name, ICollection<FirmaTasit> firmaTasits, ICollection<Ilan> ilans)
    {
        Name = name;
        FirmaTasits = firmaTasits;
        Ilans = ilans;
    }
}
