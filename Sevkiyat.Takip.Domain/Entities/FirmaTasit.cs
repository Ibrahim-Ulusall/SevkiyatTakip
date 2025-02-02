using Sevkiyat.Takip.Core.Entities;

namespace Sevkiyat.Takip.Domain.Entities;

public class FirmaTasit : BaseEntity<int>
{
    public int FirmaId { get; set; }
    public int TasitTipId { get; set; }
    public virtual Firma Firma { get; set; } = null!;
    public virtual TasitTip TasitTip { get; set; } = null!;
}
