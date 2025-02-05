using Sevkiyat.Takip.Core.Entities;

namespace Sevkiyat.Takip.Domain.Entities;
public class TasitTip : BaseEntity<int>
{
    public string Name { get; set; } = null!;
    public virtual ICollection<FirmaTasit> FirmaTasitlars { get; set; } = new List<FirmaTasit>();
    public virtual ICollection<Ilan> Ilanlars { get; set; } = new List<Ilan>();
}
