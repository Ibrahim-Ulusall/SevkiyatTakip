using Sevkiyat.Takip.Core.Entities;

namespace Sevkiyat.Takip.Domain.Entities;

public class Firma : BaseEntity<int>
{
    public string Adi { get; set; } = null!;
    public virtual ICollection<FirmaYetkili> FirmaYetkililers { get; set; } = new List<FirmaYetkili>();
    public virtual ICollection<FirmaTasit> FirmaTasitlars { get; set; } = new List<FirmaTasit>();
    public virtual ICollection<Ilan> Ilanlars { get; set; } = new List<Ilan>();
}
