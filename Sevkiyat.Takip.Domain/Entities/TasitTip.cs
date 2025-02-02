using Sevkiyat.Takip.Core.Entities;

namespace Sevkiyat.Takip.Domain.Entities;
public class TasitTip : BaseEntity<int>
{
    public string Name { get; set; } = null!;
    public virtual ICollection<FirmaTasit> FirmaTasits { get; set; }
    public TasitTip()
    {
        FirmaTasits = new List<FirmaTasit>();
    }
    public TasitTip(string name, ICollection<FirmaTasit> firmaTasits)
    {
        Name = name;
        FirmaTasits = firmaTasits;
    }
}
